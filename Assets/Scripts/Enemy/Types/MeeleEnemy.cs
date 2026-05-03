using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class MeeleEnemy : BaseEnemy
{
    private DamageDealer _damageDealer;

    protected override void Awake()
    {
        base.Awake();
        
        _damageDealer = GetComponent<DamageDealer>();
    }

    protected override void Attack()
    {
        _damageDealer.SetDamage(attackDamage);
    }
    protected override void Chase()
    {
        _isAttacking = false;

        Vector2 dir = (player.transform.position - transform.position).normalized;
        rb2D.linearVelocity = dir * moveSpeed;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f; // get the angle
        rb2D.SetRotation(angle);
    }
}
