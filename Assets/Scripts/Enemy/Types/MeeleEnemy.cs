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

        Vector2 dir = (player.transform.position - transform.position).normalized;
        rb2D.linearVelocity = dir * moveSpeed;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f; // get the angle
        rb2D.SetRotation(angle);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable) && _wasAttacking)
        {
            damageable.AddHealth(-attackDamage);
        }
        _wasAttacking = false;
    }
}
