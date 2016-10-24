using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using NiquIoC.Extensions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    internal class PartialEmitFunctionResolve : IResolve
    {
        private readonly Dictionary<Type, Func<object[], object>> _createPartialEmitFunctionForConstructorCache;
        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;

        public PartialEmitFunctionResolve(Dictionary<Type, ContainerMember> registeredTypesCache)
        {
            _registeredTypesCache = registeredTypesCache;
            _createPartialEmitFunctionForConstructorCache = new Dictionary<Type, Func<object[], object>>();
        }

        public object Resolve(ContainerMember containerMember, Action<object, ContainerMember> afterObjectCreate)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory = () => CreateInstanceFunction(containerMember, afterObjectCreate);
            }

            return containerMember.ObjectLifetimeManager.GetInstance();
        }

        public void ClearCache(Type type)
        {
            if (_createPartialEmitFunctionForConstructorCache.ContainsKey(type))
            {
                _createPartialEmitFunctionForConstructorCache.Remove(type);
            }
        }

        private object CreateInstanceFunction(ContainerMember containerMember, Action<object, ContainerMember> afterObjectCreate)
        {
            var ctorParameters = containerMember.Parameters;
            var ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the constructor and we fill it
            {
                var parameterContainerMember = _registeredTypesCache.GetValue(ctorParameters[i].ParameterType);
                parameters[i] = Resolve(parameterContainerMember, afterObjectCreate);
            }

            if (!_createPartialEmitFunctionForConstructorCache.ContainsKey(containerMember.ReturnType)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = CreateObjectFunction(containerMember);
                _createPartialEmitFunctionForConstructorCache.Add(containerMember.ReturnType, factoryMethod);
            }

            var obj = _createPartialEmitFunctionForConstructorCache[containerMember.ReturnType](parameters);
            afterObjectCreate(obj, containerMember); //when we have a new instance of the type, we have to resolve the properties and the methods also

            return obj;
        }

        //http://stackoverflow.com/questions/8219343/reflection-emit-create-object-with-parameters
        //http://stackoverflow.com/questions/13478933/reflection-emit-to-create-class-instance
        private static Func<object[], object> CreateObjectFunction(ContainerMember containerMember)
        {
            var ctor = containerMember.Constructor;
            //this method return a function that provide fast creation of a new instastance for given constructorInfo
            var dm = new DynamicMethod($"Create_{ctor.DeclaringType?.FullName.Replace('.', '_')}", typeof(object), new[] { typeof(object[]) }, true); //we create a dynamic method
            var ilgen = dm.GetILGenerator(); //we get the IL Generator from dynamic method

            var parameters = ctor.GetParameters(); //we get constructor parameters
            for (var i = 0; i < parameters.Length; i++)
            {
                ilgen.Emit(OpCodes.Ldarg_0); //first we put a correct parameter onto the stack
                EmitHelper.EmitIntOntoStack(ilgen, i); //next we put a correct index onto the stack again
                ilgen.Emit(OpCodes.Ldelem_Ref); //then we take an index and a parameter from the stack and we put the parameter in an array in a correct index
                var paramType = parameters[i].ParameterType;
                ilgen.Emit(paramType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, paramType); //finally we cast the parameter to the correct type
            }
            ilgen.Emit(OpCodes.Newobj, ctor); //at the end we create a new object that takes an array of parameters as constructor parameters
            ilgen.Emit(OpCodes.Ret); //we return created object

            return (Func<object[], object>)dm.CreateDelegate(typeof(Func<object[], object>));
        }
    }
}