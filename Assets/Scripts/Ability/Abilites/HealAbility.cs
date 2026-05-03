using UnityEngine;

public class HealAbility : BaseAbility
{
    [SerializeField] private int healAmount;
    
    protected override void Activate()
    {
        player.Heal(healAmount);
    }
}
