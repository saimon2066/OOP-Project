using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] protected float walkspeed;
    [SerializeField] protected float maxHealth, currentHealth;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected Rigidbody2D rb2D;
    [SerializeField] private TextMeshProUGUI health;

    protected abstract void Attack();

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    protected virtual void Update()
    {
        health.text = $"{currentHealth}";
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int health)
    {
        currentHealth += health;
    }
    public void DealDamage(int damage)
    {
        currentHealth--;
    }
}
