using Project.Core.Game.Scripts.Mvc.UICamera;
using Project.Core.Game.Scripts.States;
using Project.Core.Scripts.Mvc.WorldCamera;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.GameInitiator {
    public class GameInstaller : MonoInstaller{
        [SerializeField] InitialStateConfig _initialStateConfig;
        [SerializeField] private WorldCameraView worldCameraView;
        [SerializeField] private UICameraView uiCameraView;
        
        public override void InstallBindings() {
            Container.Bind<IGameInitiator>().To<GameInitiator>().AsSingle().NonLazy();
            Container.Bind<InitialStateConfig>().FromInstance(_initialStateConfig).AsSingle().NonLazy();
            Container.BindFactory<LobbyState, LobbyState.Factory>();
            Container.BindFactory<GamePlayState, GamePlayState.Factory>();
            
            Container.BindInterfacesTo<WorldCameraController>().AsSingle().WithArguments(worldCameraView).NonLazy();
            Container.BindInterfacesTo<UICameraController>().AsSingle().WithArguments(uiCameraView).NonLazy();
        }
    }
}