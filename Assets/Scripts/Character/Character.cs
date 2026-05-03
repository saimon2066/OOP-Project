using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public abstract class Character : MonoBehaviour, IDamageable
{
    [Header("Settings")]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected int maxHealth;
    [Space(5)]
    [Header("References")]
    [SerializeField] private TextMeshProUGUI healthDisplay;

    protected Rigidbody2D rb2D;

    private int _health; // without caused stack overflow
    protected int _currentHealth
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, maxHealth);

            // check for death
            if (_health <= 0)
            {
                Destroy(gameObject);
            }

            // update gui
            healthDisplay.text = $"{_health}";
        }
    }

    protected abstract void Attack();

    protected virtual void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
    public void Heal(int heal)
    {
        _currentHealth += heal;
    }
}
