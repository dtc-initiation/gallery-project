using Project.Core.Scripts.Services.CommandFactory.Base;
using Zenject;

namespace Project.Core.Scripts.Services.CommandFactory {
    public class CommandFactory : ICommandFactory{
        private DiContainer _diContainer;
        
        [Inject]
        public CommandFactory(DiContainer container) {
            _diContainer = container;
        }
        
        public TCommand CreateVoidCommand<TCommand>() where TCommand : ICommandVoid, new() {
            TCommand command = new TCommand();
            command.SetObjectResolver(_diContainer);
            command.ResolveDependencies();
            return command;
        }

        public TCommand CreateAsyncVoidCommand<TCommand>() where TCommand : ICommandAsyncVoid, new() {
            TCommand command = new TCommand();
            command.SetObjectResolver(_diContainer);
            command.ResolveDependencies();
            return command;
        }
    }
}