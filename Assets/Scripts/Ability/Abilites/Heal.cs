using UnityEngine;

public class Heal : BaseAbility
{
    [SerializeField] private Player player;

    protected override void Activate()
    {
        player.Heal(5);
    }
}
