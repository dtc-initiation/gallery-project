using System.Threading;
using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands {
    public class EnterGamePlayStateCommand : BaseCommand, ICommandAsyncVoid {
        private IOnScreenControlsController _onScreenControlsController;
        
        public override void ResolveDependencies() {
            _onScreenControlsController = _diContainer.Resolve<IOnScreenControlsController>();
        }

        public Awaitable Execute(CancellationTokenSource cancellationTokenSource) {
            _onScreenControlsController.InitializeEntry();
            return AwaitableUtils.CompletedTask;
        }
    }
}