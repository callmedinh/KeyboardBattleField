using UnityEngine;
namespace States
{
    [CreateAssetMenu(fileName = "New Throw", menuName = "States/Throw")]
    public class Throw : StateData
    {
        public Transform throwPoint;
        public GameObject projectilePrefab;
        public override void UpdateAbility(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void OnEnter(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            playerController = stateMachine.GetPlayerController(animator);
            projectilePrefab = playerController.projectilePrefab;
            throwPoint = playerController.throwPoint;
            ThrowProjectile(KeyboardManager.Instance.GetPositionOfKey(KeyboardManager.LastKeyPressed));
        }

        public override void OnExit(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            playerController.isAttacking = false;
        }
        private void ThrowProjectile(Vector2 target)
        {
            var dir = (target - new Vector2(throwPoint.position.x, playerController.gameObject.transform.position.y)).normalized;
            playerController.transform.localScale = (dir.x >= 0) ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            var proj = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
            var p = proj.GetComponent<Projectile>();
            if (p != null)
            {
                p.Initialize(dir);
            }
        }
    }
}

