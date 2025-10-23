using Project.Core.Scripts.Services.ApplicationStateMachine;
using Project.Core.Scripts.Services.InitiatorService;
using Project.Core.Scripts.Services.Logger;
using Project.Core.Scripts.Services.SceneService;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project.Core.Scripts.CoreInstaller {
    public class CoreInstaller : MonoInstaller {
        [SerializeField] private SceneDataCollection sceneDataCollection;
        
        public override void InstallBindings() {
            Container.BindInterfacesTo<UnityLogger>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneLoaderService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneInitiatorService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ApplicationStateMachine>().AsSingle().NonLazy();
            Container.Bind<SceneDataCollection>().FromInstance(sceneDataCollection).AsSingle().NonLazy();
        }
    }
}