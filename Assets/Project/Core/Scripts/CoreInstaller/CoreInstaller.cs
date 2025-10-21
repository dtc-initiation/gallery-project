using Project.Core.Scripts.Services.Logger;
using UnityEngine;
using Zenject;

namespace Project.Core.Scripts.Bootstrapping {
    public class CoreInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.BindInterfacesTo<UnityLogger>().AsSingle().NonLazy();
        }
    }
}