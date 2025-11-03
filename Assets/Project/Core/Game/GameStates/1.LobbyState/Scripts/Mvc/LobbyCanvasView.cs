using UnityEngine;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Mvc {
    public class LobbyCanvasView : MonoBehaviour {
        [SerializeField] private Canvas lobbyCanvas;
        [SerializeField] private float planeDistance;

        public void InitializeEntryPoint(Camera uiCamera) {
            lobbyCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            lobbyCanvas.worldCamera = uiCamera;
            lobbyCanvas.planeDistance = planeDistance;
            lobbyCanvas.enabled = true;
        }

        public void InitializeExit() {
            lobbyCanvas.enabled = false;
            lobbyCanvas.worldCamera = null;
        }
        
    }
}