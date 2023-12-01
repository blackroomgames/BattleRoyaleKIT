using UnityEngine;
using LasyDI;

using Code.Data;
using Code.Pool;

namespace Code.Installers
{
    public sealed class ResourcesInstaller : MonoInstaller
    {
        [SerializeField] private UnitViewData _unitViewData;

        private void Reset()
        {
            name = nameof(ResourcesInstaller);
        }

        public override void OnInstall()
        {
            LasyContainer
                .Bind<UnitPool>()
                .WithParameters(_unitViewData)
                .AsSingle();
        }
    }
}
