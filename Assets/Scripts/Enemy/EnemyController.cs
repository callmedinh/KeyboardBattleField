using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Animator animator;
        public Transform playerTransform;
        public float heartCount = 3;
        public bool isFlying;
        private Health _health;
        private Animator _aniamor;

        private void Start()
        {
            _health = new Health(3);
            _aniamor = GetComponent<Animator>();
        }

        public void SetTarget(Transform target) 
        {
            playerTransform = target;
        }
        public void TakeDamage(float damage)
        {
            heartCount -= damage;
            if (heartCount <= 0)
            {
                _aniamor.SetTrigger(nameof(TransitionParameters.Death));
            }
            else
            {
                _aniamor.SetTrigger(nameof(TransitionParameters.Hurt));
            }
        }
        

        public void CountDownTimer(float time)
        {
            StartCoroutine(TimerCoroutine(time));
        }
        IEnumerator TimerCoroutine(float time)
        {
            yield return new WaitForSeconds(time);
            isFlying = true;
            yield return null;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController player = other.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.TakeDamage(1);
                }
            }
        }
    }
}