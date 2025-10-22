using Project.Core.Game.Scripts.States;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.GameInitiator {
    public class GameInstaller : MonoInstaller{
        
        public override void InstallBindings() {
            Container.Bind<IGameInitiator>().To<GameInitiator>().AsSingle().NonLazy();
            Container.BindFactory<MainMenuState, MainMenuState.Factory>();
        }
    }
}