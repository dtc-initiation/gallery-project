using System.Threading;
using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands.Camera;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Mvc.InputController {
    public class InputController : IInputController{
        private readonly ICommandFactory  _commandFactory;
        private readonly GameInputActions  _gameInputActions;
        
        public InputController(ICommandFactory commandFactory, GameInputActions gameInputActions) {
            _commandFactory = commandFactory;
            _gameInputActions = gameInputActions;
        }
        
        public void EnableInput() {
            _gameInputActions.Enable();
            _gameInputActions.Default.Disable();
            _gameInputActions.UI.Disable();
            _gameInputActions.Camera.Enable();
        }

        public void DisableInput() {
            _gameInputActions.Disable();
        }

        public void RegisterInputListeners() {
            _gameInputActions.Camera.RotateLeft.started += OnLeftRotate;
            _gameInputActions.Camera.RotateRight.started += OnRightRotate;
        }

        public void UnregisterInputListeners() {
            _gameInputActions.Camera.RotateLeft.started -= OnLeftRotate;
            _gameInputActions.Camera.RotateRight.started -= OnRightRotate;
        }

        private void OnLeftRotate(InputAction.CallbackContext context) {
            LogService.LogTopic("Rotating Left", LogTopic.Camera);
            _commandFactory.CreateVoidCommand<RotateCameraCommand>().SetEnterData(new CameraRotationEnterData(true)).Execute();
        }

        private void OnRightRotate(InputAction.CallbackContext context) {
            LogService.LogTopic("Rotating Right", LogTopic.Camera);
            _commandFactory.CreateVoidCommand<RotateCameraCommand>().SetEnterData(new CameraRotationEnterData(false)).Execute();
        }

        public async Awaitable WaitForAnyKeyPressed(CancellationTokenSource cancellationTokenSource) {
            await AwaitableUtils.WaitUntil(AnyButtonPressed, cancellationTokenSource.Token);
        }

        private bool AnyButtonPressed() {
            return Keyboard.current?.anyKey.wasPressedThisFrame == true;
        }
    }
}