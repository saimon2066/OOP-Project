using UnityEngine;

public abstract class BaseEnemy : Character
{   
    [SerializeField] protected float attackRadius;
    [SerializeField] protected GameObject player;

    protected bool _isAttacking;
    private float _attackTime;

    protected abstract void Chase();

    protected override void Start()
    {
        base.Start();

        _attackTime = attackCooldown;
    }
    protected virtual void Update()
    {
        if (player != null)
        {
            _isAttacking = Vector3.Distance(rb2D.position, player.transform.position) < attackRadius;

            if (_isAttacking)
            {
                rb2D.linearVelocity = Vector2.zero;

                if (_attackTime > Mathf.Epsilon)
                {
                    _attackTime -= Time.deltaTime;
                }
                if (_attackTime <= Mathf.Epsilon)
                {
                    Attack();
                    _attackTime = attackCooldown;
                }
            }
            else
            {
                Chase();
            }   
        }
    }
}
