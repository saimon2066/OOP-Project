using UnityEngine;

public class FireballAbiltiy : BaseAbility
{
    [SerializeField] private GameObject fireballPrefab;
    
    protected override void Activate()
    {
        Instantiate(fireballPrefab, transform.position, Quaternion.identity);
    }
}
