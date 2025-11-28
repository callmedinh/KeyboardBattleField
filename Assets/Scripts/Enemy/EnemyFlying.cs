using States;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "New Enemy Flying", menuName = "States/Enemy Flying")]
    public class EnemyFlying : EnemyStateData
    {
        private Transform _target;
        private Rigidbody2D _rb;
        PlayerController _playerController;
        public float flyeSpeed = 5f;

        public override void UpdateAbility(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            if (_playerController.isInvincible) return;
            var direction = (_target.position - enemyController.transform.position).normalized;
            _rb.linearVelocity = direction * flyeSpeed;
        }

        public override void OnEnter(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            enemyController = stateMachine.GetEnemyController(animator);
            _rb = enemyController.rb;
            _target = enemyController.playerTransform;
            _playerController = _target.GetComponent<PlayerController>();
        }

        public override void OnExit(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            enemyController.isFlying = false;
        }
    }
}