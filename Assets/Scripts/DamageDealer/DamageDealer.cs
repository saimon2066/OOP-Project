using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private enum DamageType
    {
        TriggerStay, TriggerEnter, CollisionEnter
    }
    [SerializeField] private DamageType damageType;
    [SerializeField] private bool resetCanDamage;
    [SerializeField] private bool destroyOnHit;
    private int _damage;
    private bool _canDamage;

    public void SetDamage(int damage)
    {
        _damage = damage;
        _canDamage = true;
    }

    private void DealDamage(GameObject target)
    {
        if (target.TryGetComponent(out IDamageable damageable) && _canDamage)
        {
            damageable.TakeDamage(_damage);
        }
        if (resetCanDamage) _canDamage = false;
        if (destroyOnHit) Destroy(gameObject);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damageType == DamageType.CollisionEnter)
        {
            DealDamage(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (damageType == DamageType.TriggerStay)
        {
            DealDamage(collider.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (damageType == DamageType.TriggerEnter)
        {
            DealDamage(collider.gameObject);
        }
    }
}
