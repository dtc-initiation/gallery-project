using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.GameInitiator {
    public class GameInstaller : MonoInstaller{
        [SerializeField] private IGameInitiator _gameInitiator;
        
        public override void InstallBindings() {
            Container.Bind<IGameInitiator>().FromInstance(_gameInitiator).AsSingle().NonLazy();
        }
    }
}