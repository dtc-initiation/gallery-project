using UnityEngine;

namespace Project.Core.Scripts.Mvc.UICamera {
    public class UICameraView : MonoBehaviour{
        [field:SerializeField] public Camera Camera { get;private set; }
    }
}