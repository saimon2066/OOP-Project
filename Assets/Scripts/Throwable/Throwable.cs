using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Throwable : MonoBehaviour
{
    [SerializeField] private float despawnTime;
    [SerializeField] protected float speed;

    protected Rigidbody2D rb2D;
            
    public abstract void Throw(Vector2 direction, int damage);
    
    protected virtual void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected IEnumerator DespawnCoroutine()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
