using UnityEngine;

namespace States
{
    [CreateAssetMenu(fileName = "New Idle", menuName = "States/Idle")]
    public class Idle : StateData
    {
        public override void UpdateAbility(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            if (Vector2.SqrMagnitude(playerController.moveInput) > 0.01)
            {
                animator.SetBool(nameof(TransitionParameters.Move), true);
            }

            if (playerController.jump)
            {
                animator.SetBool(nameof(TransitionParameters.Jump), true);
            }

            if (playerController.isAttacking)
            {
                animator.SetTrigger(nameof(TransitionParameters.Attack));
            }
        }

        public override void OnEnter(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            playerController = stateMachine.GetPlayerController(animator);
        }

        public override void OnExit(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
