using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] protected float walkspeed;
    [SerializeField] protected float attackSpeed;
    [SerializeField] private TextMeshProUGUI healthDisplay;

    protected Rigidbody2D rb2D;

    [SerializeField] protected int maxHealth;
    protected int _currentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;

            // check for death
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }

            // update gui
            healthDisplay.text = $"{_currentHealth}";
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

    public void AddHealth(int add)
    {
        _currentHealth += add;
    }
}
