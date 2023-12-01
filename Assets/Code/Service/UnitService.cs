using UnityEngine;
using Code.Pool;

using Code.Unit;

namespace Code.Service
{
    public sealed class UnitService
    {
        private readonly UnitPool UnitPool;

        public UnitService(UnitPool unitPool)
        {
            UnitPool = unitPool;
        }

        //TODO Modfication
        //FAST DEV TEST
        public void CreateUnit(string prefabName, Vector3 positon)
        {
            var view = UnitPool.Spawn(prefabName);
            view.transform.position = positon;

            new UnitPresentor(
                new UnitModel(),
                view,
                strategy: null,
                UnitPool);
        }
    }
}
