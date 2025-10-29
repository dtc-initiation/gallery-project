using Abiogenesis3d;
using Project.Core.Game.Scripts.Mvc.CameraSystem.UICamera;
using Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera;
using Project.Core.Scripts.Services.Logger.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.PixelCamera {
    public class PixelCameraController : IPixelCameraController{
        private readonly WorldCameraView _worldCameraView;
        private readonly UICameraView _uiCameraView;
        private readonly GameObject _uPixelatorPrefab;
        private readonly GameObject _pixelArtEdgeHighlightsPrefab;
        
        private UPixelator _uPixelator;
        private PixelArtEdgeHighlights _pixelArtEdgeHighlights;

        [Inject]
        public PixelCameraController(WorldCameraView worldCameraView, UICameraView uiCameraView, GameObject uPixelatorPrefab, GameObject pixelArtEdgeHighlightsPrefab) {
            _worldCameraView = worldCameraView;
            _uiCameraView = uiCameraView;
            _uPixelatorPrefab = uPixelatorPrefab;
            _pixelArtEdgeHighlightsPrefab = pixelArtEdgeHighlightsPrefab;
        }
        
        public void InitializeEntry() {
            LogService.LogTopic("Initializing Entry : PixelCameraController");
            InitializeUPixelator();
            InitializePixelArtEdgeHighlights();
            LogService.LogTopic("Initialized Entry : PixelCameraController");
        }

        private void InitializeUPixelator() {
            GameObject instance = Object.Instantiate(_uPixelatorPrefab);
            instance.name = "UPixelator";

            _uPixelator = instance.GetComponent<UPixelator>();

            RemoveAutoUnpack(instance);

            _uPixelator.autoDetectCameras = false;
            _uPixelator.mirroredCamera = _worldCameraView.Camera;

            _uPixelator.cameraInfos.Clear();
            _uPixelator.cameraInfos.Add(new UPixelatorCameraInfo {
                cam = _worldCameraView.Camera,
                snap = true,
                stabilize = true,
                orthographicSizeCorrectionEnabled = true
            });

            _uPixelator.Refresh();
        }

        private void InitializePixelArtEdgeHighlights() {
            GameObject instance = Object.Instantiate(_pixelArtEdgeHighlightsPrefab);
            instance.name = "PixelArtEdgeHighlights";

            _pixelArtEdgeHighlights = instance.GetComponent<PixelArtEdgeHighlights>();

            RemoveAutoUnpack(instance);

            _pixelArtEdgeHighlights.autoDetectCameras = false;
            _pixelArtEdgeHighlights.cameraInfos.Clear();
            _pixelArtEdgeHighlights.cameraInfos.Add(new PixelArtEdgeHighlightsCameraInfo {
                cam = _worldCameraView.Camera
            });
        }

        private void RemoveAutoUnpack(GameObject instance) {
            var autoUnpack = instance.GetComponent<AutoUnpackPrefab>();
            if (autoUnpack != null) {
                Object.Destroy(autoUnpack);
            }
        }

    }
}