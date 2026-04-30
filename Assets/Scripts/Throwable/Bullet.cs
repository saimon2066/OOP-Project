using UnityEngine;

public class Bullet : Throwable
{
    private int _damage;

    public override void Throw(Vector2 direction, int damage)
    {
        rb2D.linearVelocity = direction * speed;
        _damage = damage;
        
        StartCoroutine(DespawnCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.AddHealth(-_damage);
            Destroy(gameObject);
        }
    }
}
