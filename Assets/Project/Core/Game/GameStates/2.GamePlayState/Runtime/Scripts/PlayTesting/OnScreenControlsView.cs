using UnityEngine;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting {
    public class OnScreenControlsView : MonoBehaviour {
        [SerializeField] private Canvas onScreenControlCanvas;

        public void InitializeEntryPoint(Camera uiCamera) {
            onScreenControlCanvas.worldCamera = uiCamera;
            onScreenControlCanvas.enabled = true;
        }

        public void InitializeExitPoint() {
            onScreenControlCanvas.enabled = false;
            onScreenControlCanvas.worldCamera = null;
        }
    }
}

