using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.UICamera {
    public class UICameraView : MonoBehaviour{
        [field:SerializeField] public Camera Camera { get;private set; }
    }
}