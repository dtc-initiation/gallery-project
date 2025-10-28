using UnityEngine;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Mvc {
    public class LobbyCanvasView : MonoBehaviour {
        [SerializeField] private Canvas lobbyCanvas;

        public void InitializeEntryPoint(Camera uiCamera) {
            lobbyCanvas.worldCamera = uiCamera;
        }
    }
}