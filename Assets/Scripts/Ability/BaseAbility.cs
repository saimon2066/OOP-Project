using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseAbility : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string displayName;
    [SerializeField] protected InputAction abilityAction;
    [SerializeField] protected float cooldown;
    [Space(5)]
    [Header("References")]
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] protected Player player;

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
            display.text = $"{displayName}: {(int)_time}";
        }
        else
        {
            display.text = $"{displayName}: READY";
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
