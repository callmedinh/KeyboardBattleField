using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlugIn : MonoBehaviour
    {
        private Rigidbody2D _rb;
        public float returnDelay = 2f;
        private bool _isRight;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        public void Init(bool moveRight)
        {
            _isRight = moveRight;
            _rb.linearVelocityX = moveRight ? 5f : -5f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController player = other.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.TakeDamage(1);
                }
            }

            if (other.CompareTag("Socket"))
            {
                _rb.linearVelocity = Vector2.zero;
            }
        }

        IEnumerator BackToOrigin()
        {
            yield return new WaitForSeconds(returnDelay);
            _rb.linearVelocityX = (_isRight) ? -5f : 5f;
        }
    }
}