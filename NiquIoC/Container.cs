using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NiquIoC.Attributes;

namespace NiquIoC
{
    public class Container : IContainer
    {
        public Container()
        {
            _classContainer = new Dictionary<Type, RegisterTypeInfo>();
            _interfaceContainer = new Dictionary<Type, RegisterTypeInfo>();
            _constructorInfoForType = new Dictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>>();
            _createObjectFunctionForConstructor = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _propertiesInfoForType = new Dictionary<Type, List<PropertyInfo>>();
        }

        #region Private Fields

        private readonly Dictionary<Type, RegisterTypeInfo> _classContainer;
        private readonly Dictionary<Type, RegisterTypeInfo> _interfaceContainer;

        private readonly Dictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>> _constructorInfoForType;
        private readonly Dictionary<Type, List<PropertyInfo>> _propertiesInfoForType;
        private readonly Dictionary<ConstructorInfo, Func<object[], object>> _createObjectFunctionForConstructor;

        #endregion

        #region IContainer

        public void RegisterType<T>(bool isSingleton)
            where T : class
        {
            if (!_classContainer.ContainsKey(typeof (T)))
            {
                _classContainer.Add(typeof (T), new RegisterTypeInfo(isSingleton, typeof (T), null));
            }
            else
            {
                _classContainer[typeof (T)] = new RegisterTypeInfo(isSingleton, typeof (T), null);
            }
        }

        public void RegisterType<TFrom, TTo>(bool isSingleton)
            where TTo : TFrom
        {
            if (!_interfaceContainer.ContainsKey(typeof (TFrom)))
            {
                _interfaceContainer.Add(typeof (TFrom), new RegisterTypeInfo(isSingleton, typeof (TTo), null));
            }
            else
            {
                _interfaceContainer[typeof (TFrom)] = new RegisterTypeInfo(isSingleton, typeof (TTo), null);
            }
        }

        public void RegisterInstance<T>(T instance)
        {
            if (typeof (T).IsInterface)
            {
                if (!_interfaceContainer.ContainsKey(typeof (T)))
                {
                    _interfaceContainer.Add(typeof (T), new RegisterTypeInfo(true, instance.GetType(), instance));
                }
                else
                {
                    _interfaceContainer[typeof (T)] = new RegisterTypeInfo(true, instance.GetType(), instance);
                }
            }
            else
            {
                if (!_classContainer.ContainsKey(typeof (T)))
                {
                    _classContainer.Add(typeof (T), new RegisterTypeInfo(true, typeof (T), instance));
                }
                else
                {
                    _classContainer[typeof (T)] = new RegisterTypeInfo(true, typeof (T), instance);
                }
            }
        }

        public T Resolve<T>()
        {
            var resolvedTypes = new Dictionary<Type, bool>();
            var instance = (T) Resolve(typeof (T), resolvedTypes);
            return instance;
        }

        public void BuildUp<T>(T instance)
        {
            var resolvedTypes = new Dictionary<Type, bool>();
            ResolveProperty(instance, typeof (T), resolvedTypes);
        }

        #endregion

        #region Private Methods

        private object Resolve(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            if (type.IsInterface)
            {
                if (_interfaceContainer.ContainsKey(type))
                {
                    RegisterTypeInfo result = _interfaceContainer[type];

                    if (!result.IsSingleton)
                        return CreateInstance(result.ReturnType, resolvedTypes);


                    object value = result.Instance;
                    if (value == null)
                    {
                        value = CreateInstance(result.ReturnType, resolvedTypes);
                        _interfaceContainer[type] = new RegisterTypeInfo(result.IsSingleton, result.ReturnType, value);
                    }

                    return value;

                }
            }
            else
            {
                if (_classContainer.ContainsKey(type))
                {
                    RegisterTypeInfo result = _classContainer[type];

                    if (!result.IsSingleton)
                        return CreateInstance(type, resolvedTypes);

                    object value = result.ReturnType;
                    if (value == null)
                    {
                        value = CreateInstance(type, resolvedTypes);
                        _classContainer[type] = new RegisterTypeInfo(result.IsSingleton, type, value);
                    }

                    return value;

                }
            }

            throw new InvalidOperationException("Brak rejestracji podanej klasy");
        }

        private object CreateInstance(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            CheckResolvingTypes(resolvedTypes, type);

            if (!_constructorInfoForType.ContainsKey(type))
            {
                CreateCacheConstructorForType(type, resolvedTypes);
            }

            ConstructorInfo ctor = _constructorInfoForType[type].Item1;
            List<ParameterInfo> ctorParameters = _constructorInfoForType[type].Item2;
            int ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++)
            {
                parameters[i] = Resolve(ctorParameters[i].ParameterType, resolvedTypes);
            }

            if (!_createObjectFunctionForConstructor.ContainsKey(ctor))
            {
                Func<object[], object> factoryMethod = EmitHelper.CreateObjectFunction(ctor);
                _createObjectFunctionForConstructor.Add(ctor, factoryMethod);
            }

            object obj = _createObjectFunctionForConstructor[ctor](parameters);
            resolvedTypes[type] = true;
            ResolveProperty(obj, type, resolvedTypes);

            return obj;
        }

        private void CreateCacheConstructorForType(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            ConstructorInfo[] allConstructors = type.GetConstructors();

            int maxParameter = -1;
            IList<ConstructorInfo> goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof (DependencyConstrutor), false).Any()).ToList();
            if (!goodConstructors.Any())
            {
                maxParameter = allConstructors.Max(c => c.GetParameters().Length);
                goodConstructors = allConstructors.Where(c => c.GetParameters().Length == maxParameter).ToList();
            }

            if (goodConstructors.Count == 1)
            {
                ConstructorInfo constructor = goodConstructors.First();
                List<ParameterInfo> consParameters = constructor.GetParameters().ToList();
                if (maxParameter == -1)
                {
                    maxParameter = consParameters.Count;
                }

                var parameters = new object[maxParameter];
                for (var i = 0; i < maxParameter; i++)
                {
                    parameters[i] = Resolve(consParameters[i].ParameterType, resolvedTypes);
                }

                _constructorInfoForType.Add(type, Tuple.Create(constructor, consParameters));
            }
            else
            {
                throw new InvalidOperationException("Brak odpowiedniego konstruktora");
            }
        }

        private void ResolveProperty(object obj, Type type, Dictionary<Type, bool> resolvedTypes)
        {
            if (!_propertiesInfoForType.ContainsKey(type))
            {
                _propertiesInfoForType.Add(type, type.GetProperties().Where(p => p.GetCustomAttributes(typeof (DependencyProperty), false).Any() && p.SetMethod != null).ToList());
            }

            List<PropertyInfo> properties = _propertiesInfoForType[type];
            foreach (PropertyInfo property in properties)
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