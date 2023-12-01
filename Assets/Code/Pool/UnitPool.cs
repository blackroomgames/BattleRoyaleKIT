using BlackBox.Pool;

using Code.Unit;

namespace Code.Pool
{
    public sealed class UnitPool : BasePoolComplex<string, UnitView>
    {
        protected override void OnDespawn(UnitView despawnedObject)
        {
            despawnedObject.gameObject.SetActive(false);
        }

        protected override void OnSpawn(UnitView spawnedObject, string key)
        {
            spawnedObject.gameObject.SetActive(true);
        }
    }
}
