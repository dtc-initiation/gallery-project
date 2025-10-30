using System.Threading;
using UnityEngine;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Mvc.InputController {
    public interface IInputController {
        void EnableInput();
        void DisableInput();
        void RegisterInputListeners();
        void UnregisterInputListeners();
        Awaitable WaitForAnyKeyPressed(CancellationTokenSource cancellationTokenSource);
    }
}