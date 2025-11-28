using Unity.VisualScripting;
using UnityEngine;
namespace States
{
    public class Hurt : StateData
    {
        public override void UpdateAbility(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void OnEnter(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            playerController = stateMachine.GetComponent<PlayerController>();
        }

        public override void OnExit(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
