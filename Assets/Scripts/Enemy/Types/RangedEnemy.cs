using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    [SerializeField] private GameObject bulletPrefab;

    protected override void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, rb2D.position, Quaternion.identity);  

        Rigidbody2D bulletRb2D = bullet.GetComponent<Rigidbody2D>();
        Vector2 dir = (playerRb2D.position - rb2D.position).normalized;

        bulletRb2D.linearVelocity = dir * 10;   
    }
    protected override void Chase()
    {
        Vector2 dir = (playerRb2D.position - rb2D.position).normalized;
        rb2D.linearVelocity = dir * walkspeed;
    }
}
