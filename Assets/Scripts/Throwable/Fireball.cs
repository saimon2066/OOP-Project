using UnityEngine;

public class Fireball : Throwable
{
    protected override void Throw(Transform target)
    {
        Vector2 dir = (target.position - transform.position).normalized;
        rb2D.linearVelocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.AddHealth(-damage);
        }
    }
}
