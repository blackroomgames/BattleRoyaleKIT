using System;
using System.Collections.Generic;
using LasyDI;
using BlackGUI.MVC.Factory;

namespace BlackBox.Factory
{
    public sealed class BlackGUIWithDIFactory : IFactory
    {
        private HashSet<Type> _bindedType;

        public BlackGUIWithDIFactory()
        {
            _bindedType = new HashSet<Type>();
        }

        public T Create<T, V>()
            where T : class, V
            where V : IFactoryProduct
        {
            if (_bindedType.Contains(typeof(T)))
            {
                return LasyContainer.GetObject<T>();
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
        }

        public void Bind<T>()
            where T : class, IFactoryProduct
        {
            if (!_bindedType.Contains(typeof(T)))
            {
                _bindedType.Add(typeof(T));
                LasyContainer.Bind<T>().AsSingle();
            }
        }
    }
}
