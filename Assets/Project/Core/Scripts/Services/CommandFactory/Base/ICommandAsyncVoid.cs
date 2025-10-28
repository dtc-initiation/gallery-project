using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Services.CommandFactory.Base {
    public interface ICommandAsyncVoid : IBaseCommand {
        Awaitable Execute(CancellationTokenSource cancellationTokenSource);
    }
}