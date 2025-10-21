using Zenject;

namespace Project.Core.Scripts.Services.CommandFactory.Base {
    public abstract class BaseCommand : IBaseCommand {
        private DiContainer _diContainer;
        
        public void SetObjectResolver(DiContainer diContainer) {
            _diContainer = diContainer;
        }

        public abstract void ResolveDependencies();
    }
}