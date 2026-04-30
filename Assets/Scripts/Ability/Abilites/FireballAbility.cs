using UnityEngine;

public class FireballAbility : BaseAbility
{
    [SerializeField] private int fireballDamage;
    [SerializeField] private GameObject fireballPrefab;
    
    protected override void Activate()
    {
        GameObject fireballObj = Instantiate(fireballPrefab, player.transform.position, Quaternion.identity);
        Fireball fireball = fireballObj.GetComponent<Fireball>();

        fireball.Throw(player.transform.up, fireballDamage);
    }
}
