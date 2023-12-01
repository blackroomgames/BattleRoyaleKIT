using System;
using System.Collections.Generic;

namespace BlackBox.Pool
{
    public abstract class BasePoolComplex<K, T>
        where T : UnityEngine.Component
    {
        private IDictionary<K, Pool> _pools;

        public BasePoolComplex()
        {
            _pools = new Dictionary<K, Pool>();
        }

        public bool ContainOf(K key) => _pools.ContainsKey(key);

        public virtual void AddPrototype(K key, T prototype)
        {
            RemovePrototype(key);

            var pool = new Pool(prototype);
            _pools.Add(key, pool);

        }

        public virtual void RemovePrototype(K key)
        {
            if(_pools.TryGetValue(key, out var pool))
            {
                pool.Dispose();
                _pools.Remove(key);
            }
        }

        public T Spawn(K key)
        {
            if(_pools.TryGetValue(key, out var pool))
            {
                var spawnedObject = pool.Spawn();
                OnSpawn(spawnedObject, key);

                return spawnedObject;
            }

            throw new NullReferenceException($"[Pool Complex] In complex [ - {this.GetType().Name}, not found prototype with key - {key}");
        }

        public void Despawn(K key, T despawnedObject)
        {
            if(_pools.TryGetValue(key, out var pool))
            {
                pool.Despawn(despawnedObject);
                OnDespawn(despawnedObject);
            }
        }

        protected virtual void OnSpawn(T spawnedObject, K key) { }
        protected virtual void OnDespawn(T despawnedObject) { }

        protected class Pool : BaseAllocatedObjectPool<T>
        {
            public Pool(T prototype) : base(prototype)
            {
            }

            protected override void OnDespawn(T despawnedObject)
            {
                despawnedObject.gameObject.SetActive(false);
            }

            protected override void OnSpawn(T spawnedObject)
            {
                spawnedObject.gameObject.SetActive(true);
            }
        }
    }
}
