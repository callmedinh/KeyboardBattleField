using UnityEngine;

namespace Enemy
{
    public abstract class EnemyStateData : ScriptableObject
    {
        protected EnemyController enemyController;
        public abstract void UpdateAbility(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo);
        public abstract void OnEnter(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo);
        public abstract void OnExit(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo);
    }
}