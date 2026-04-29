using UnityEngine;

public abstract class BaseEnemy : Character
{   
    [SerializeField] protected float attackRadius;
    [SerializeField] protected Rigidbody2D playerRb2D;

    protected bool _isAttacking;
    private float _attackTime;

    protected abstract void Chase();

    protected override void Start()
    {
        base.Start();

        _attackTime = attackSpeed;
    }
    protected override void Update()
    {
        base.Update();

        _isAttacking = Vector3.Distance(rb2D.position, playerRb2D.position) < attackRadius;

        if (playerRb2D != null)
        {
            if (_isAttacking)
            {
                rb2D.linearVelocity = Vector2.zero;

                if (_attackTime > 0f)
                {
                    _attackTime -= Time.deltaTime;
                }
                if (_attackTime <= 0f)
                {
                    Attack();
                    _attackTime = attackSpeed;
                }
            }
            else
            {
                Chase();
            }   
        }
    }
}
