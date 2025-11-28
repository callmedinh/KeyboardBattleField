using UnityEngine;
namespace States
{
    [CreateAssetMenu(fileName = "New Jump", menuName = "States/Jump")]
    public class Jump : StateData
    {
        public float jumpForce = 10f;
        public override void UpdateAbility(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void OnEnter(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            playerController = stateMachine.GetPlayerController(animator);
            playerController.rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }

        public override void OnExit(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
