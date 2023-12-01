using UnityEngine;
using LasyDI;

using Code.Service;

namespace Code.DevTools
{
    public sealed class DevUnitSpawner : MonoBehaviour
    {
        private UnitService _unitService;

        private void Start()
        {
            _unitService = LasyContainer.GetObject<UnitService>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)) // key 1
            {
                _unitService.CreateUnit("Dev_Unit_View_Player", new Vector3(35, 0, 35));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) // key 2
            {
                _unitService.CreateUnit("Dev_Unit_View_Enemy", new Vector3(-35, 0, -35));
            }

        }
    }
}
