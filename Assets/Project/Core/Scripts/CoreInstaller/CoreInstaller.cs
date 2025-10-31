using Project.Core.Scripts.Services.ApplicationStateMachine;
using Project.Core.Scripts.Services.CommandFactory;
using Project.Core.Scripts.Services.InitiatorService;
using Project.Core.Scripts.Services.Logger;
using Project.Core.Scripts.Services.SceneService;
using Project.Core.Scripts.Services.SceneService.Base;
using Project.Core.Scripts.Services.UpdateSubscriptionManager.Base;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project.Core.Scripts.CoreInstaller {
    public class CoreInstaller : MonoInstaller {
        [SerializeField] private UpdateSubscriptionService updateSubscriptionService;
        [SerializeField] private SceneDataCollection sceneDataCollection;
        
        public override void InstallBindings() {
            Container.BindInterfacesTo<UnityLogger>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneLoaderService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneInitiatorService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ApplicationStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesTo<CommandFactory>().AsSingle().CopyIntoAllSubContainers().NonLazy();
            Container.Bind<SceneDataCollection>().FromInstance(sceneDataCollection).AsSingle().NonLazy();
            Container.BindInterfacesTo<UpdateSubscriptionService>().FromInstance(updateSubscriptionService).AsSingle().NonLazy();
            Container.Bind<GameInputActions>().AsSingle().NonLazy();
            
        }
    }
}