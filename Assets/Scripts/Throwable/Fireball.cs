using UnityEngine;

public class Fireball : Throwable
{
    private int _damage;

    public override void Throw(Vector2 direction, int damage)
    {
        rb2D.linearVelocity = direction * speed;
        _damage = damage;

        StartCoroutine(DespawnCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hit");
        if (collider.TryGetComponent(out IDamageable damageable) && !collider.CompareTag("Player"))
        {
            damageable.AddHealth(-_damage);
        }
    }
}
