using Zenject;

namespace Project.Core.Game.GameStates._2.GamePlayState.Scripts.Initiator {
    public class GamePlayInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IGamePlayInitiator>().To<GamePlayInitiator>().AsSingle().NonLazy();
        }
    }
}