using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LasyDI;

using Code.Service;

namespace Code.Installers
{
    public sealed class CoreInstaller : MonoInstaller
    {
        private void Reset()
        {
            name = nameof(CoreInstaller);
        }

        public override void OnInstall()
        {
            LasyContainer
                .Bind<UnitService>()
                .AsSingle();
        }
    }
}
