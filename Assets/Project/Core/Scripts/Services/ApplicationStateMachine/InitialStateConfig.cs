using UnityEngine;

namespace Project.Core.Scripts.Services.ApplicationStateMachine.Base {
    [CreateAssetMenu(fileName = "InitialStateConfig", menuName = "Core/Services/InitialStateConfig")]
    public class InitialStateConfig : ScriptableObject, IInitialStateConfig {
        [SerializeField] public ApplicationStateType initialStateType;
    }
}