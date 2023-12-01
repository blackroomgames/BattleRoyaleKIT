using System;

using BlackBox.Factory;

namespace BlackBox.Pool
{
    /// <summary>
    /// Основной интерфейс пула объектов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPool<T> : IContainablePool
        where T : UnityEngine.Object
    {
        IFactory<T> Factory { get; }

        public T Spawn();
        public void Despawn(T despawnedObject);
    }
}
