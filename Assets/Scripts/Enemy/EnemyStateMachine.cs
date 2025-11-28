using System.Collections.Generic;
using States;
using UnityEngine;

namespace Enemy
{
    public class EnemyStateMachine : StateMachineBehaviour
    {
        public EnemyController enemyController;
        public List<EnemyStateData> listAbilityData;

        private void UpdateAll(Animator animator, EnemyStateMachine stateMachine, AnimatorStateInfo stateInfo)
        {
            foreach (var abilityData in listAbilityData)
            {
                abilityData.UpdateAbility(animator, stateMachine, stateInfo);
            }
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            foreach (var abilityData in listAbilityData)
            {
                abilityData.OnEnter(animator, this, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            UpdateAll(animator, this, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            foreach (var abilityData in listAbilityData)
            {
                abilityData.OnExit(animator, this, stateInfo);
            }
        }
        
        public EnemyController GetEnemyController(Animator animator)
        {
            if (enemyController == null)
            {
                enemyController = animator.GetComponent<EnemyController>();
            }
            return enemyController;
        }
    }
}