using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Mvc.InputController;
using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting;
using Project.Core.Scripts.Services.AudioService;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Initiator {
    public class GamePlayInstaller : MonoInstaller {
        [SerializeField] private OnScreenControlsView _onScreenControlView;
        [SerializeField] private AudioDataScriptableObject _gamePlayAudioScriptableObject;
        
        public override void InstallBindings() {
            Container.Bind<IGamePlayInitiator>().To<GamePlayInitiator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<OnScreenControlsController>().AsSingle().WithArguments(_onScreenControlView).NonLazy();
            Container.BindInterfacesTo<InputController>().AsSingle().NonLazy();
            Container.Bind<AudioDataScriptableObject>().FromInstance(_gamePlayAudioScriptableObject).AsSingle().NonLazy();
        }
    }

}