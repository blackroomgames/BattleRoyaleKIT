using UnityEngine;
using BlackBox.Pool;

using Code.Map;
using Code.Other;

namespace Code.Pool
{
    public sealed class MapItemPool : BasePoolComplex<string, MapItem>
    {
        private GameObject _itemRoot;

        public MapItemPool()
        {
            _itemRoot = new GameObject("ItemRoot");
            MonoBehaviour.DontDestroyOnLoad(_itemRoot);
        }

        public MapItem Spawn(string key, Vector3 pivotPoint, float radius)
        {
            var result = base.Spawn(key);
            result.transform.position = NavigationHandler.GetNavigationPointInRange(pivotPoint, radius) + Vector3.up * 0.5f;
            result.transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(default, 180f));
            result.transform.SetParent(_itemRoot.transform);

            return result;
        }

        protected override void OnDespawn(MapItem despawnedObject)
        {
            despawnedObject.gameObject.SetActive(false);
        }

        protected override void OnSpawn(MapItem spawnedObject, string key)
        {
            spawnedObject.gameObject.SetActive(true);
        }
    }
}
