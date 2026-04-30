using UnityEngine;

public class HealAbility : BaseAbility
{
    [SerializeField] private Player player;

    protected override void Activate()
    {
        player.AddHealth(5);
    }
}
