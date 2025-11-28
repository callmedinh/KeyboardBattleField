using Unity.VisualScripting;
using UnityEngine;

namespace States
{
    [CreateAssetMenu(fileName = "New Death", menuName = "States/Death")]
    public class Death : StateData
    {
        public override void UpdateAbility(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
        
        }

        public override void OnEnter(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
        
        }

        public override void OnExit(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            GameEvents.OnDeath?.Invoke();
        }
    }
}

