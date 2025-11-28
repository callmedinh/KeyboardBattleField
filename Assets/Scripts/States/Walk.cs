using Core;
using DefaultNamespace;
using UnityEngine;
namespace States
{
    [CreateAssetMenu(fileName = "New Walk", menuName = "States/Walk")]
    public class Walk : StateData
    {
        private Rigidbody2D _rb;
        public float walkSpeed = 5f;
        public override void UpdateAbility(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            if (!playerController.Grounded()) return;
            if (playerController.moveInput.x > 0)
            {
                _rb.linearVelocity = Vector2.right * walkSpeed;
                playerController.transform.localScale = new Vector3(1, 1, 1);
            } else if (playerController.moveInput.x < 0)
            {
                _rb.linearVelocity = Vector2.left * walkSpeed;
                playerController.transform.localScale = new Vector3(-1, 1, 1);
            } else if (Mathf.Abs(playerController.moveInput.x) < 0.01f)
            {
                animator.SetBool(nameof(TransitionParameters.Move), false);
            }

            if (playerController.jump)
            {
                animator.SetBool(nameof(TransitionParameters.Jump), true);
            }

            if (playerController.isAttacking)
            {
                animator.SetTrigger(nameof(TransitionParameters.Attack));
            }
            SoundManager.Instance.PlayEffect(audioData);
        }

        public override void OnEnter(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            playerController = stateMachine.GetPlayerController(animator);
            _rb = playerController.rb;
        }

        public override void OnExit(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
