using System;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Mvc {
    public class LobbyButtonView : MonoBehaviour {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI buttonText;

        private Action<ApplicationStateType> _onClick;
        private ApplicationStateType _toState;
        
        public void Setup(Action<ApplicationStateType> onClick, ApplicationStateType toState) {
            _onClick = onClick;
            _toState = toState;
            AddListeners();
        }

        private void AddListeners() {
            button.onClick.AddListener(OnClick);
        }

        private void RemoveListeners() {
            button.onClick.RemoveListener(OnClick);
        }

        private void OnClick() {
            _onClick?.Invoke(_toState);
        }

    }
}