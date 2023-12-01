﻿using System.Linq;
using System.Collections.Generic;

namespace BlackBox.Pool
{
    /// <summary>
    /// Базовый класс пула игровых объектов, с хранением объектов созданных на игровой сцене.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseAllocatedObjectPool <T> : BaseObjectPool<T>
        where T: UnityEngine.Object
    {
        private HashSet<T> _allocatedObjects;

        public BaseAllocatedObjectPool(T prototype) : base(prototype)
        {
            _allocatedObjects = new HashSet<T>();
        }

        protected IReadOnlyList<T> AllocetedObjects => _allocatedObjects.ToArray();

        new public T Spawn()
        {
            var spawnedObject = base.Spawn();

            if (!_allocatedObjects.Contains(spawnedObject))
                _allocatedObjects.Add(spawnedObject);

            return spawnedObject;
        }

        new public void Despawn(T despawnObject)
        {
            _allocatedObjects.Remove(despawnObject);

            base.Despawn(despawnObject);
        }

        protected override void OnDispose()
        {
            foreach(var el in _allocatedObjects)
            {
                Destroy(el);
            }

            _allocatedObjects.Clear();
            _allocatedObjects = null;
        }
    }
}
