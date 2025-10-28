using Zenject;

namespace Project.Core.Scripts.Services.CommandFactory.Base {
    public interface IBaseCommand {
        void SetObjectResolver(DiContainer diContainer);
        void ResolveDependencies();
    }
}