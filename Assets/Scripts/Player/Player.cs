using UnityEngine;

public class Player : Character
{
    private bool _wasPressed;

    protected override void Attack()
    {
        _wasPressed = true;
    }

    private void Update()
    {
        Vector2 moveInput = InputManager.instance.inputs.Player.Move.ReadValue<Vector2>();
        rb2D.linearVelocity = moveInput * walkspeed;

        if (InputManager.instance.inputs.Player.Attack.WasPressedThisFrame())
        {
            Attack();
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
