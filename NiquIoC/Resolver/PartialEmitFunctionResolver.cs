using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using NiquIoC.Extensions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC.Resolver
{
    internal class PartialEmitFunctionResolver : IResolver
    {
        private readonly Dictionary<Type, Func<object[], object>>
            _createPartialEmitFunctionForConstructorCache;

        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;

        public PartialEmitFunctionResolver(Dictionary<Type, ContainerMember> registeredTypesCache)
        {
            _registeredTypesCache = registeredTypesCache;
            _createPartialEmitFunctionForConstructorCache =
                new Dictionary<Type, Func<object[], object>>();
        }

        public object Resolve(ContainerMember containerMember,
            Action<object, ContainerMember> afterObjectCreate)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory =
                    () => GetObject(containerMember, afterObjectCreate);
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

        private object GetObject(ContainerMember containerMember,
            Action<object, ContainerMember> afterObjectCreate)
        {
            var ctorParameters = containerMember.Parameters;
            var ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            //we create as array with the parameters of the constructor and we fill it
            for (var i = 0; i < ctorParametersCount; i++)
            {
                var parameterContainerMember =
                    _registeredTypesCache.GetValue(ctorParameters[i].ParameterType);
                parameters[i] = Resolve(parameterContainerMember, afterObjectCreate);
            }

            var obj = CreateInstanceFunction(containerMember, parameters);
            //when we have a new instance of the type, we have to resolve the properties and the methods also
            afterObjectCreate(obj, containerMember);

            return obj;
        }

        private object CreateInstanceFunction(ContainerMember containerMember, object[] parameters)
        {
            //if we do not have a create object function in the cache, we create it
            if (!_createPartialEmitFunctionForConstructorCache.ContainsKey(containerMember
                .ReturnType))
            {
                var factoryMethod = CreateObjectFunction(containerMember);
                _createPartialEmitFunctionForConstructorCache.Add(containerMember.ReturnType,
                    factoryMethod);
            }

            var obj =
                _createPartialEmitFunctionForConstructorCache[containerMember.ReturnType](
                    parameters);
            return obj;
        }

        //this method return a function that provide fast creation of a new instastance for given constructorInfo
        //to create this function I read this threads:
        //http://stackoverflow.com/questions/8219343/reflection-emit-create-object-with-parameters
        //http://stackoverflow.com/questions/13478933/reflection-emit-to-create-class-instance
        private static Func<object[], object> CreateObjectFunction(ContainerMember containerMember)
        {
            var ctor = containerMember.Constructor;
            //we create a dynamic method
            var dm = new DynamicMethod($"Create_{ctor.DeclaringType?.FullName.Replace('.', '_')}",
                typeof(object), new[] {typeof(object[])}, true);
            //we get the IL Generator from dynamic method
            var ilgen = dm.GetILGenerator();

            //we get constructor parameters
            var parameters = ctor.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
            {
                //first we put a correct parameter onto the stack
                ilgen.Emit(OpCodes.Ldarg_0);
                //next we put a correct index onto the stack again
                EmitHelper.EmitIntOntoStack(ilgen, i);
                //then we take an index and a parameter from the stack and we put the parameter in an array in a correct index
                ilgen.Emit(OpCodes.Ldelem_Ref);
                var paramType = parameters[i].ParameterType;
                //finally we cast the parameter to the correct type
                ilgen.Emit(paramType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass,
                    paramType);
            }
            //at the end we create a new object that takes an array of parameters as constructor parameters
            ilgen.Emit(OpCodes.Newobj, ctor);
            //we return created object
            ilgen.Emit(OpCodes.Ret);

            return (Func<object[], object>) dm.CreateDelegate(typeof(Func<object[], object>));
        }
    }
}