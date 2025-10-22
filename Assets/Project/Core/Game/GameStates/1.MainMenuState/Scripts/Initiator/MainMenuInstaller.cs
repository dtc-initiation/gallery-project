using Zenject;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Initiator {
    public class MainMenuInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IMainMenuInitiator>().To<MainMenuInitiator>().AsSingle().NonLazy();
        }
    }
}