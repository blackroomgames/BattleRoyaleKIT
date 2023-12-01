using System;
using System.Collections.Generic;
using BlackECS.Components;
using BlackECS.ComponnetFactory;
using LasyDI;

namespace BlackBox.Factory
{
    public sealed class ComponentFactory : IComponentFactory
    {
        private HashSet<Type> _bindedTypes;

        public ComponentFactory()
        {
            _bindedTypes = new HashSet<Type>();
        }

        T IComponentFactory.CreateComponent<T>()
        {
            if (_bindedTypes.Contains(typeof(T)))
                return LasyContainer.GetObject<T>();
            else
                return Activator.CreateInstance<T>();
        }

        public void Bind<T>()
            where T : class, IComponent
        {
            if (_bindedTypes.Contains(typeof(T))) return;
                
            _bindedTypes.Add(typeof(T));
            LasyContainer.Bind<T>();
        }
    }
}
