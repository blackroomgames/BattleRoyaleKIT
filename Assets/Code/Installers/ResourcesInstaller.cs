using LasyDI;

namespace Code.Installers
{
    public sealed class ResourcesInstaller : MonoInstaller
    {
        private void Reset()
        {
            name = nameof(ResourcesInstaller);
        }

        public override void OnInstall()
        {
        }
    }
}
