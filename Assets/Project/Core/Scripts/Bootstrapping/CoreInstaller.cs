using UnityEngine;
using Zenject;

namespace Project.Core.Scripts.Bootstrapping {
    public class CoreInstaller : MonoInstaller {
        public override void InstallBindings() {
            Debug.Log("CoreInstaller: Installing Core");
        }
    }
}