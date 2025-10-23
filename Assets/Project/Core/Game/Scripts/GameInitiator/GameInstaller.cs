using Project.Core.Game.Scripts.States;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.GameInitiator {
    public class GameInstaller : MonoInstaller{
        [SerializeField] InitialStateConfig _initialStateConfig;
        
        public override void InstallBindings() {
            Container.Bind<IGameInitiator>().To<GameInitiator>().AsSingle().NonLazy();
            Container.Bind<InitialStateConfig>().FromInstance(_initialStateConfig).AsSingle().NonLazy();
            Container.BindFactory<MainMenuState, MainMenuState.Factory>();
        }
    }
}