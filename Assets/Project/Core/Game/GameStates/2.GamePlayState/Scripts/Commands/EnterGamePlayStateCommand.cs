using System.Threading;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;

namespace Project.Core.Game.GameStates._2.GamePlayState.Scripts.Commands {
    public class EnterGamePlayStateCommand : BaseCommand, ICommandAsyncVoid {
        public override void ResolveDependencies() {
            
        }

        public Awaitable Execute(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }
    }
}