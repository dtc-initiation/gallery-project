using System;
using System.Threading;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.Logger.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Scripts.Services.ApplicationStateMachine {
    public class ApplicationStateMachine : IApplicationStateService {
        private readonly IApplicationState _initialState;
        private IApplicationState _currentState;
        public IApplicationState CurrentState() => _currentState;

        [Inject]
        public ApplicationStateMachine(IApplicationState initialState) {
            _initialState = initialState;
        }
        
        
        public async Awaitable EnterInitialGameState(CancellationTokenSource cancellationTokenSource) {
            _currentState = _initialState;
            await _initialState.LoadState(cancellationTokenSource);
            await _initialState.StartState(cancellationTokenSource);
        }

        public void SwitchState(IApplicationState newState) {
            _ = SwitchStateAsync(newState);
        }

        private async Awaitable SwitchStateAsync(IApplicationState newState) {
            try {
                var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(Application.exitCancellationToken);
                if (_currentState == null) {
                    LogService.LogError("InitialState not set");
                    return;
                }

                // TODO LoadingScreen On
                await _currentState.ExitState(cancellationTokenSource);
                _currentState = newState;
                await _currentState.LoadState(cancellationTokenSource);
                // TODO LoadingScreen Hide
                await _currentState.StartState(cancellationTokenSource);

            } catch (OperationCanceledException) {
                LogService.Log("State switch operation cancelled");
            } catch (Exception e) {
                LogService.LogError(e.Message);
                throw;
            }
        }
    }
}