using Zenject;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Initiator {
    public class LobbyInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<ILobbyInitiator>().To<LobbyInitiator>().AsSingle().NonLazy();
        }
    }
}