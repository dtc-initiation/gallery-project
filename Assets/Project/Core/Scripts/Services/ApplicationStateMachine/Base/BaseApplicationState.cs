using System.Threading;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;

namespace Project.Core.Scripts.Services.ApplicationStateMachine.Base {
    public abstract class BaseApplicationState : IApplicationState {
        private readonly CancellationTokenSource _cancelTokenSource;

        protected BaseApplicationState() {
            _cancelTokenSource = new CancellationTokenSource();
        }

        public CancellationTokenSource CancelTokenSource => CancellationTokenSource.CreateLinkedTokenSource(_cancelTokenSource.Token);
        
        public abstract ApplicationStateType ApplicationStateType { get; }
        
        public virtual Awaitable LoadState(CancellationTokenSource cancellationTokenSource) {
            LogService.LogTopic($"Load state : {ApplicationStateType}", LogTopic.Core);
            return AwaitableUtils.CompletedTask;
        }

        public virtual Awaitable StartState(CancellationTokenSource cancellationTokenSource) {
            LogService.LogTopic($"Start state : {ApplicationStateType}", LogTopic.Core);
            return AwaitableUtils.CompletedTask;
        }

        public virtual Awaitable ExitState(CancellationTokenSource cancellationTokenSource) {
            _cancelTokenSource.Cancel();
            LogService.LogTopic($"Exit state : {ApplicationStateType}", LogTopic.Core);
            return AwaitableUtils.CompletedTask;
        }
    }
}