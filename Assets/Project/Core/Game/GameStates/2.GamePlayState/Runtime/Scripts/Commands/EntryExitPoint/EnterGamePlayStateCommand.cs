using System.Threading;
using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting;
using Project.Core.Scripts.Services.AudioService;
using Project.Core.Scripts.Services.AudioService.Base;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands {
    public class EnterGamePlayStateCommand : BaseCommand, ICommandAsyncVoid {
        private IOnScreenControlsController _onScreenControlsController;
        private IAudioService _audioService;
        private AudioDataScriptableObject _audioDataScriptableObject;
        
        public override void ResolveDependencies() {
            _onScreenControlsController = _diContainer.Resolve<IOnScreenControlsController>();
            _audioService = _diContainer.Resolve<IAudioService>();
            _audioDataScriptableObject = _diContainer.Resolve<AudioDataScriptableObject>();
        }

        public Awaitable Execute(CancellationTokenSource cancellationTokenSource) {
            _onScreenControlsController.InitializeEntry();
            _audioService.AddAudio(_audioDataScriptableObject);
            return AwaitableUtils.CompletedTask;
        }
    }
}