using UnityEngine;
using LasyDI;

using Code.Data;
using Code.Other;
using Code.Pool;

namespace Code.Map
{
    public class MapItemCreatePoint : MonoBehaviour, IItemCreatePoint
    {
        [SerializeField] private MapItemData _data;
        [SerializeField] private float _radius;

        protected MapItem item;

        public MapItemData Data { get; }
        public float Radius { get; }

        protected MapItemPool Pool { get; private set; }

        private void Start()
        {
            Pool = LasyContainer.GetObject<MapItemPool>();
            Create();
        }

        public virtual void Create()
        {
            var createChance = Random.Range(default, _data.MaxItemChance);
            //Debug.Log($"createChance - {createChance}");
            if (_data.TryGetObject(out var itemPrefab, createChance))
            {
                if (!Pool.ContainOf(itemPrefab.name))
                {
                    Pool.AddPrototype(itemPrefab.name, itemPrefab);
                }

                item = Pool.Spawn(itemPrefab.name, transform.position, _radius);
                item.OnPutUpItem += ReturnItem;
            }
        }

        protected virtual void ReturnItem(MapItem item)
        {
            this.item = null;
            item.OnPutUpItem -= ReturnItem;
            Pool.Despawn(item.name, item);
        }

#if UNITY_EDITOR

        protected virtual Color DrawColor => Color.magenta;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, .5f);
        }

        private void OnDrawGizmosSelected()
        {
            var color = DrawColor;
            color.a = 0.25f;
            Gizmos.color = color;
            Gizmos.DrawSphere(transform.position, _radius);
        }
#endif
    }
}
