using Project.Core.Scripts.Services.InitiatorService;
using Project.Core.Scripts.Services.Logger;
using Project.Core.Scripts.Services.SceneService;
using UnityEngine;
using Zenject;

namespace Project.Core.Scripts.Bootstrapping {
    public class CoreInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.BindInterfacesTo<UnityLogger>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneLoaderService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneInitiatorService>().AsSingle().NonLazy();
        }
    }
}