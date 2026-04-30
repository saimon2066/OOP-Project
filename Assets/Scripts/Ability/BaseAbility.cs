using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected InputAction abilityAction;
    [SerializeField] protected float cooldown;

    protected float _time;

    protected virtual void Update()
    {
        if (abilityAction.WasPerformedThisFrame() && _time <= Mathf.Epsilon)
        {
            Activate();
            _time = cooldown;
        }
        if (_time > Mathf.Epsilon)
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
