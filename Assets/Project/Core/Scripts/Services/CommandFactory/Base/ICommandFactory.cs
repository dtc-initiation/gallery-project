namespace Project.Core.Scripts.Services.CommandFactory.Base {
    public interface ICommandFactory {
        TCommand CreateVoidCommand<TCommand>() where TCommand : ICommandVoid, new();
        TCommand CreateAsyncVoidCommand<TCommand>() where TCommand : ICommandAsyncVoid, new();
    }
}