using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] protected InputAction abilityAction;
    [SerializeField] protected float cooldown;

    protected float _time;

    protected virtual void Update()
    {
        if (abilityAction.WasPerformedThisFrame() && _time <= 0)
        {
            Activate();
            _time = cooldown;
        }

        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
    }
    protected abstract void Activate();

    private void OnEnable()
    {
        abilityAction.Enable();
    }
    private void OnDisable()
    {
        abilityAction.Disable();
    }
}
