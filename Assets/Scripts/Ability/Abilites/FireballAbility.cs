using UnityEngine;

public class FireballAbility : BaseAbility
{
    [SerializeField] private int fireballDamage;
    [SerializeField] private GameObject fireballPrefab;
    
    protected override void Activate()
    {
        GameObject fireballObj = Instantiate(fireballPrefab, player.transform.position, Quaternion.identity);
        Throwable fireball = fireballObj.GetComponent<Throwable>();

        fireball.Throw(player.transform.up, fireballDamage);
    }
}
