using UnityEngine;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting {
    public class OnScreenControlsView : MonoBehaviour {
        [SerializeField] private Canvas onScreenControlCanvas;
        [SerializeField] private float planeDistance;

        public void InitializeEntryPoint(Camera uiCamera) {
            onScreenControlCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            onScreenControlCanvas.worldCamera = uiCamera;
            onScreenControlCanvas.planeDistance = planeDistance;
            onScreenControlCanvas.enabled = true;
        }

        public void InitializeExitPoint() {
            onScreenControlCanvas.enabled = false;
            onScreenControlCanvas.worldCamera = null;
        }
    }
}

