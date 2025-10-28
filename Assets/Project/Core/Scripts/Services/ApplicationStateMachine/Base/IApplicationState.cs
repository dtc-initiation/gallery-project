using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Services.ApplicationStateMachine.Base {
    public interface IApplicationState {
        CancellationTokenSource CancelTokenSource { get; }
        Awaitable LoadState(CancellationTokenSource cancellationTokenSource);
        Awaitable StartState(CancellationTokenSource cancellationTokenSource);
        Awaitable ExitState(CancellationTokenSource cancellationTokenSource);
    }
}