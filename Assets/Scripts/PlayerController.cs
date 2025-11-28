
using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Throwing")]
    public bool isAttacking;
    public GameObject projectilePrefab;
    public Transform throwPoint;
    [Header("Jump")]
    public bool jump;
    public Transform feetPoint;
    [Header("References")]
    public Animator animator;
    public Rigidbody2D rb;
    public PlayerInputHandler playerInputHandler;
    public Vector2 moveInput;
    public LayerMask groundLayer;
    public bool isInvincible = false;
    public float invincibleDuration = 0.5f;
    public Health Health;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Health = new Health(3);
        Health.OnHealthChanged += HealthOnOnHealthChanged;
    }

    private void HealthOnOnHealthChanged(int arg1, int arg2)
    {
        if (arg1 <= 0)
        {
            HealthOnOnDeath();
        }
        else
        {
            HealthOnOnHurt();
        }
    }

    #region Heald Procedures
    private void HealthOnOnHurt()
    {
        animator.SetTrigger(nameof(TransitionParameters.Hurt));
    }

    private void HealthOnOnDeath()
    {
        animator.SetTrigger(nameof(TransitionParameters.Death));
    }
    public void TakeDamage(int damage)
    {
        if (isInvincible) return;
        Health.TakeDamage(damage);
        StartCoroutine(InvincibilityCoroutine(invincibleDuration));
    }
    IEnumerator InvincibilityCoroutine(float time)
    {
        isInvincible = true;
        yield return new WaitForSeconds(time);
        isInvincible = false;
    }
    #endregion
    public bool Grounded()
    {
        return Physics2D.OverlapCircle(feetPoint.position, 0.1f, groundLayer);
    }

}
public enum TransitionParameters
{
    Move,
    Jump,
    Attack,
    Fly,
    Death,
    Hurt
}




