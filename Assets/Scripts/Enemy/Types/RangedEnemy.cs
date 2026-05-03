using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    [SerializeField] private GameObject bulletPrefab;

    protected override void Attack()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);  
        Throwable bullet = bulletObj.GetComponent<Throwable>();

        Vector2 dir = (player.transform.position - transform.position).normalized;

        bullet.Throw(dir, attackDamage);
    }
    protected override void Chase()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        rb2D.linearVelocity = dir * moveSpeed;
    }
}
