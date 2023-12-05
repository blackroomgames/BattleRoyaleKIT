using UnityEngine;
using UnityEngine.AI;

namespace Code.Other
{
    public static class NavigationHandler
    {
        public static Vector3 GetNavigationPointInRange(Vector3 pivot, float range)
        {
            pivot += Random.insideUnitSphere * range;            
            NavMesh.SamplePosition(pivot, out var hit, range, 1);

            return hit.position;
        }
    }
}
