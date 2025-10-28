using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Services.ApplicationStateMachine.Base {
    public interface IApplicationStateService {
        IApplicationState CurrentState();
        Awaitable EnterInitialGameState(IApplicationState initialState, CancellationTokenSource cancellationTokenSource);
        void SwitchState(IApplicationState newState);
    }
}