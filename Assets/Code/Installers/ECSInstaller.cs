using LasyDI;

namespace Code.Installers
{
    public sealed class ECSInstaller : MonoInstaller
    {
        private void Reset()
        {
            name = nameof(ECSInstaller);
        }

        public override void OnInstall()
        {
        }
    }
}
