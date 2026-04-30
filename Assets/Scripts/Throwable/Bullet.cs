using UnityEngine;

public class Bullet : Throwable
{
    protected override void Throw(Transform target)
    {
        Vector2 dir = (target.position - transform.position).normalized;
        rb2D.linearVelocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.AddHealth(-damage);
            Destroy(gameObject);
        }
    }
}
