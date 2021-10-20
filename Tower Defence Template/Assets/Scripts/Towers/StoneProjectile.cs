using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneProjectile : Projectile
{
    StoneProjectile()
    {
        moveSpeed = 10;
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Move()
    {
        base.Move();
    }
    protected override void OnHitEnemy()
    {
        target.GetComponent<Enemy>().TakeDamage(attackDamage);
        Destroy(gameObject);
    }
}
