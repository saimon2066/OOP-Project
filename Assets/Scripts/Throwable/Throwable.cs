using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Throwable : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;

    protected Rigidbody2D rb2D;
            
    protected abstract void Throw(Transform target);
    
    protected virtual void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
}
