using States;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "New Enemy Idle", menuName = "States/Enemy Idle")]
    public class EnemyIdle : EnemyStateData
    {
        public override void UpdateAbility(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            if (enemyController == null)
            {
                enemyController = stateMachine.GetEnemyController(animator);
                enemyController.CountDownTimer(3f);
            }
            if (enemyController.isFlying) 
            {
                animator.SetBool(nameof(TransitionParameters.Fly), true);
            }
        }

        public override void OnEnter(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void OnExit(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}