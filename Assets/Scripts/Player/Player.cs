using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    private bool _wasPressed;
    private float _attackTime;

    protected override void Attack()
    {
        _wasPressed = true;
    }

    private void OnEnable()
    {
        InputManager.instance.inputs.Player.Attack.performed += OnPlayerAttackPerformed;
    }
    private void OnDisable()
    {
        InputManager.instance.inputs.Player.Attack.performed -= OnPlayerAttackPerformed;
    }
    protected override void Start()
    {
        base.Start();

        _attackTime = attackCooldown;
    }
    private void Update()
    {
        Vector2 moveInput = InputManager.instance.inputs.Player.Move.ReadValue<Vector2>();
        rb2D.linearVelocity = moveInput * moveSpeed;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); // get mouse pos
        Vector2 dir = mousePos - (Vector2)transform.position; // get direction to mouse
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f; // get the angle
        rb2D.SetRotation(angle);

        if (_attackTime > Mathf.Epsilon)
        {
            _attackTime -= Time.deltaTime;
        }
    }

    private void OnPlayerAttackPerformed(InputAction.CallbackContext context)
    {
        if (_attackTime <= Mathf.Epsilon)
        {
            Attack();
            _attackTime = attackCooldown;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageable damageable) && _wasPressed)
        {
            damageable.AddHealth(-1);
        }
        _wasPressed = false;
    }
}
