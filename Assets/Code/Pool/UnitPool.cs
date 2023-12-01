using System.Collections.Generic;
using BlackBox.Pool;

using Code.Unit;
using Code.Data;

namespace Code.Pool
{
    public sealed class UnitPool : BasePoolComplex<string, UnitView>
    {
        public UnitPool(UnitViewData data)
        {
            AddPrototypes(data.EnemyView);
            AddPrototypes(data.PlayerView);
        }

        protected override void OnDespawn(UnitView despawnedObject)
        {
            despawnedObject.gameObject.SetActive(false);
        }

        protected override void OnSpawn(UnitView spawnedObject, string key)
        {
            spawnedObject.gameObject.SetActive(true);
        }

        private void AddPrototypes(IReadOnlyList<UnitView> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                AddPrototype(list[i].name, list[i]);
            }
        }
    }
}
