using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace SampleContainer
{
    public class PoorContainerWithCache : IContainer
    {
        private readonly Dictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>> _cache;
        private readonly Dictionary<Type, List<PropertyInfo>> _cacheProperty;
        private readonly Dictionary<Type, Tuple<bool, object>> _classContainer;
        private readonly Dictionary<ConstructorInfo, Func<object[], object>> _createCache;
        private readonly Dictionary<Type, Tuple<bool, Type, object>> _interfaceContainer;

        public PoorContainerWithCache()
        {
            _classContainer = new Dictionary<Type, Tuple<bool, object>>();
            _interfaceContainer = new Dictionary<Type, Tuple<bool, Type, object>>();
            _cache = new Dictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>>();
            _createCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _cacheProperty = new Dictionary<Type, List<PropertyInfo>>();
        }

        #region IContainer

        public void RegisterType<T>(bool singleton)
            where T : class
        {
            if (!_classContainer.ContainsKey(typeof (T)))
            {
                _classContainer.Add(typeof (T), Tuple.Create(singleton, (object) null));
            }
            else
            {
                _classContainer[typeof (T)] = Tuple.Create(singleton, (object) null);
            }
        }

        public void RegisterType<TFrom, TTo>(bool singleton)
            where TTo : TFrom
        {
            if (!_interfaceContainer.ContainsKey(typeof (TFrom)))
            {
                _interfaceContainer.Add(typeof (TFrom), Tuple.Create(singleton, typeof (TTo), (object) null));
            }
            else
            {
                _interfaceContainer[typeof (TFrom)] = Tuple.Create(singleton, typeof (TTo), (object) null);
            }
        }

        public void RegisterInstance<T>(T instance)
        {
            if (typeof (T).IsInterface)
            {
                if (!_interfaceContainer.ContainsKey(typeof (T)))
                {
                    _interfaceContainer.Add(typeof (T), Tuple.Create(true, instance.GetType(), (object) instance));
                }
                else
                {
                    _interfaceContainer[typeof (T)] = Tuple.Create(true, instance.GetType(), (object) instance);
                }
            }
            else
            {
                if (!_classContainer.ContainsKey(typeof (T)))
                {
                    _classContainer.Add(typeof (T), Tuple.Create(true, (object) instance));
                }
                else
                {
                    _classContainer[typeof (T)] = Tuple.Create(true, (object) instance);
                }
            }
        }

        public T Resolve<T>()
        {
            Dictionary<Type, bool> resolvedTypes = new Dictionary<Type, bool>();
            var instance = (T) Resolve(typeof (T), resolvedTypes);
            resolvedTypes = null;
            return instance;
        }

        public void BuildUp<T>(T instance)
        {
            Dictionary<Type, bool> resolvedTypes = new Dictionary<Type, bool>();
            ResolveProperty(instance, typeof (T), resolvedTypes);
            resolvedTypes = null;
        }

        #endregion

        #region Private Methods

        private object Resolve(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            if (type.IsInterface)
            {
                if (_interfaceContainer.ContainsKey(type))
                {
                    var result = _interfaceContainer[type];
                    if (result.Item1)
                    {
                        object value = result.Item3;
                        if (value == null)
                        {
                            value = CreateInstance(result.Item2, resolvedTypes);
                            _interfaceContainer[type] = Tuple.Create(result.Item1, result.Item2, value);
                        }

                        return value;
                    }
                    return CreateInstance(result.Item2, resolvedTypes);
                }
            }
            else
            {
                if (_classContainer.ContainsKey(type))
                {
                    var result = _classContainer[type];
                    if (result.Item1)
                    {
                        object value = result.Item2;
                        if (value == null)
                        {
                            value = CreateInstance(type, resolvedTypes);
                            _classContainer[type] = Tuple.Create(result.Item1, value);
                        }

                        return value;
                    }
                    return CreateInstance(type, resolvedTypes);
                }
            }

            throw new InvalidOperationException("Brak rejestracji podanej klasy");
        }

        private object CreateInstance(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            CheckResolvingTypes(resolvedTypes, type);

            if (!_cache.ContainsKey(type))
            {
                CreateCacheConstructorForType(type, resolvedTypes);
            }

            var ctor = _cache[type].Item1;
            var ctorParameters = _cache[type].Item2;
            int ctorParametersCount = ctorParameters.Count;

            object[] parameters = new object[ctorParametersCount];
            for (int i = 0; i < ctorParametersCount; i++)
            {
                parameters[i] = Resolve(ctorParameters[i].ParameterType, resolvedTypes);
            }

            if (!_createCache.ContainsKey(ctor))
            {
                CreateCacheForConstructor(ctor);
            }

            var obj = _createCache[ctor](parameters);
            resolvedTypes[type] = true;
            ResolveProperty(obj, type, resolvedTypes);

            return obj;
        }

        private void CreateCacheForConstructor(ConstructorInfo ctor)
        {
            var dm = new DynamicMethod($"_CreationFacotry_{Guid.NewGuid()}", typeof (object), new[] {typeof (object[])}, true);
            var ilgen = dm.GetILGenerator();
            ilgen.DeclareLocal(typeof (int));
            ilgen.DeclareLocal(typeof (object));

            ilgen.Emit(OpCodes.Ldc_I4_0); // [0]
            ilgen.Emit(OpCodes.Stloc_0); //[nothing]

            var parameters = ctor.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                EmitInt32(ilgen, i); // [args][index]
                ilgen.Emit(OpCodes.Stloc_0); // [args][index]
                ilgen.Emit(OpCodes.Ldarg_0); //[args]
                EmitInt32(ilgen, i); // [args][index]
                ilgen.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
                var paramType = parameters[i].ParameterType;
                if (paramType != typeof (object))
                {
                    ilgen.Emit(OpCodes.Castclass, paramType); //Cast to Type t
                }
            }
            ilgen.Emit(OpCodes.Newobj, ctor); //[new-object]
            //ilgen.Emit(OpCodes.Stloc_1); // nothing
            //ilgen.Emit(OpCodes.Ldloc_1); //[new-object]
            ilgen.Emit(OpCodes.Ret);

            var factoryMethod = (Func<object[], object>) dm.CreateDelegate(typeof (Func<object[], object>));

            _createCache.Add(ctor, factoryMethod);
        }

        private void EmitInt32(ILGenerator il, int value)
        {
            switch (value)
            {
                case -1:
                    il.Emit(OpCodes.Ldc_I4_M1);
                    break;
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    break;
                default:
                    if (value >= -128 && value <= 127)
                    {
                        il.Emit(OpCodes.Ldc_I4_S, (sbyte) value);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldc_I4, value);
                    }
                    break;
            }
        }

        private void CreateCacheConstructorForType(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            var allConstructors = type.GetConstructors();

            int maxParameter = -1;
            IEnumerable<ConstructorInfo> goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof (DependencyConstrutor), false).Any()).ToList();
            if (!goodConstructors.Any())
            {
                maxParameter = allConstructors.Max(c => c.GetParameters().Count());
                goodConstructors = allConstructors.Where(c => c.GetParameters().Count() == maxParameter);
            }

            if (goodConstructors.Count() == 1)
            {
                var constructor = goodConstructors.First();
                var consParameters = constructor.GetParameters().ToList();
                if (maxParameter == -1)
                {
                    maxParameter = consParameters.Count;
                }

                object[] parameters = new object[maxParameter];
                for (int i = 0; i < maxParameter; i++)
                {
                    parameters[i] = Resolve(consParameters[i].ParameterType, resolvedTypes);
                }

                _cache.Add(type, Tuple.Create(constructor, consParameters));
            }
            else
            {
                throw new InvalidOperationException("Brak odpowiedniego konstruktora");
            }
        }

        private void ResolveProperty(object obj, Type type, Dictionary<Type, bool> resolvedTypes)
        {
            if (!_cacheProperty.ContainsKey(type))
            {
                _cacheProperty.Add(type, type.GetProperties().Where(p => p.GetCustomAttributes(typeof (DependencyProperty), false).Any() && p.SetMethod != null).ToList());
            }

            var properties = _cacheProperty[type];
            foreach (var property in properties)
            {
                property.SetValue(obj, Resolve(property.PropertyType, resolvedTypes));
            }
        }

        private void CheckResolvingTypes(Dictionary<Type, bool> resolvedTypes, Type type)
        {
            if (resolvedTypes.ContainsKey(type))
            {
                if (!resolvedTypes[type])
                {
                    throw new InvalidOperationException("Cycle in class " + type);
                }
            }
            else
            {
                resolvedTypes.Add(type, false);
            }
        }

        #endregion
    }
}