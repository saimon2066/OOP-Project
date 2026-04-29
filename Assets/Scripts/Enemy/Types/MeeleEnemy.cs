using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MeeleEnemy : BaseEnemy
{
    private bool _wasAttacking;

    protected override void Attack()
    {
        _wasAttacking = true;
    }
    protected override void Chase()
    {
        _isAttacking = false;

        Vector2 dir = (playerRb2D.position - rb2D.position).normalized;
        rb2D.linearVelocity = dir * walkspeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable) && _wasAttacking)
        {
            damageable.DealDamage(1);
        }
        _wasAttacking = false;
    }
}
