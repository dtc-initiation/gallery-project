using Project.Core.Game.Scripts.Mvc.CameraSystem.PixelCamera;
using Project.Core.Game.Scripts.Mvc.CameraSystem.UICamera;
using Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera;
using Project.Core.Game.Scripts.States;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.GameInitiator {
    public class GameInstaller : MonoInstaller{
        [SerializeField] InitialStateConfig _initialStateConfig;
        [SerializeField] private WorldCameraView worldCameraView;
        [SerializeField] private UICameraView uiCameraView;
        [SerializeField] private GameObject _uPixelatorPrefab;
        [SerializeField] private GameObject _pixelArtEdgeHighlightsPrefab;
        
        public override void InstallBindings() {
            Container.Bind<IGameInitiator>().To<GameInitiator>().AsSingle().NonLazy();
            Container.Bind<InitialStateConfig>().FromInstance(_initialStateConfig).AsSingle().NonLazy();
            Container.BindFactory<LobbyState, LobbyState.Factory>();
            Container.BindFactory<GamePlayState, GamePlayState.Factory>();
            
            Container.BindInterfacesTo<WorldCameraController>().AsSingle().WithArguments(worldCameraView).NonLazy();
            Container.BindInterfacesTo<UICameraController>().AsSingle().WithArguments(uiCameraView).NonLazy();
            Container.BindInterfacesTo<PixelCameraController>().AsSingle().WithArguments(worldCameraView, uiCameraView, _uPixelatorPrefab, _pixelArtEdgeHighlightsPrefab).NonLazy();
        }
    }
}