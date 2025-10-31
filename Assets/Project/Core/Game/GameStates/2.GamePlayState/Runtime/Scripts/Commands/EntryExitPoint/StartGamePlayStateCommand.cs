using System.Threading;
using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Mvc.InputController;
using Project.Core.Scripts.Services.CommandFactory.Base;
using UnityEngine;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands {
    public class StartGamePlayStateCommand : BaseCommand, ICommandAsyncVoid {
        private IInputController _inputController;
        
        public override void ResolveDependencies() {
            _inputController = _diContainer.Resolve<IInputController>();
        }

        public async Awaitable Execute(CancellationTokenSource cancellationTokenSource) {
            _inputController.RegisterInputListeners();
            _inputController.EnableInput();
            await _inputController.WaitForAnyKeyPressed(cancellationTokenSource);
        }
    }
}