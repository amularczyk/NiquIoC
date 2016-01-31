using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NiquIoC
{
    public class Container : IContainer
    {
        Dictionary<Type, Tuple<bool, object>> _classContainer;
        Dictionary<Type, Tuple<bool, Type, object>> _interfaceContainer;

        public Container()
        {
            _classContainer = new Dictionary<Type, Tuple<bool, object>>();
            _interfaceContainer = new Dictionary<Type, Tuple<bool, Type, object>>();
        }

        #region IContainer Members

        public void RegisterType<T>(bool singleton)
            where T : class
        {
            if (!_classContainer.ContainsKey(typeof(T)))
            {
                _classContainer.Add(typeof(T), Tuple.Create(singleton, (object)null));
            }
            else
            {
                _classContainer[typeof(T)] = Tuple.Create(singleton, (object)null);
            }
        }

        public void RegisterType<From, To>(bool singleton)
            where To : From
        {
            if (!_interfaceContainer.ContainsKey(typeof(From)))
            {
                _interfaceContainer.Add(typeof(From), Tuple.Create(singleton, typeof(To), (object)null));
            }
            else
            {
                _interfaceContainer[typeof(From)] = Tuple.Create(singleton, typeof(To), (object)null);
            }
        }

        public void RegisterInstance<T>(T instance)
        {
            if (typeof(T).IsInterface)
            {
                if (!_interfaceContainer.ContainsKey(typeof(T)))
                {
                    _interfaceContainer.Add(typeof(T), Tuple.Create(true, instance.GetType(), (object)instance));
                }
                else
                {
                    _interfaceContainer[typeof(T)] = Tuple.Create(true, instance.GetType(), (object)instance);
                }
            }
            else
            {
                if (!_classContainer.ContainsKey(typeof(T)))
                {
                    _classContainer.Add(typeof(T), Tuple.Create(true, (object)instance));
                }
                else
                {
                    _classContainer[typeof(T)] = Tuple.Create(true, (object)instance);
                }
            }
        }

        public T Resolve<T>()
        {
            var result = _interfaceContainer[typeof(T)];
            return (T)CreateInstance(result.Item2);
        }

        #endregion

        private object CreateInstance(Type type)
        {
            return CreateInstance1(type);
        }

        private object CreateInstance1(Type type)
        {
            return Activator.CreateInstance(type);
        }

        delegate object MethodInvoker();
        MethodInvoker methodHandler = null;
        bool _created = false;
        
        void CreateMethod(Type type)
        {
            ConstructorInfo target = type.GetConstructor(Type.EmptyTypes);
            DynamicMethod dynamic = new DynamicMethod(string.Empty,
                        typeof(object),
                        new Type[0],
                        target.DeclaringType);
            ILGenerator il = dynamic.GetILGenerator();
            il.DeclareLocal(target.DeclaringType);
            il.Emit(OpCodes.Newobj, target);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);

            methodHandler = (MethodInvoker)dynamic.CreateDelegate(typeof(MethodInvoker));
        }

        public object CreateInstance2(Type type)
        {
            if (!_created)
            {
                CreateMethod(type);
                _created = true;
            }
            return methodHandler();
        }
    }
}
