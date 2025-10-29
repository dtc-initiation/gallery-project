using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Initiator {
    public class GamePlayInstaller : MonoInstaller {
        [SerializeField] private OnScreenControlsView _onScreenControlView;
        public override void InstallBindings() {
            Container.Bind<IGamePlayInitiator>().To<GamePlayInitiator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<OnScreenControlsController>().AsSingle().WithArguments(_onScreenControlView).NonLazy();
        }
    }

}