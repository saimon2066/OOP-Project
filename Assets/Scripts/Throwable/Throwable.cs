using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(DamageDealer))]
public class Throwable : MonoBehaviour
{
    [SerializeField] private float despawnTime;
    [SerializeField] private float speed;

    private Rigidbody2D _rb2D;
    private DamageDealer _damageDealer;
            
    public void Throw(Vector2 direction, int damage)
    {
        _rb2D.linearVelocity = direction * speed;
        _damageDealer.SetDamage(damage);

        StartCoroutine(DespawnCoroutine());
    }
    
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _damageDealer = GetComponent<DamageDealer>();
    }

    private IEnumerator DespawnCoroutine()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
