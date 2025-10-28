using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.UICamera {
    public class UICameraView : MonoBehaviour, ICameraView {
        [field:SerializeField] public Camera Camera { get; set; }
    }
}