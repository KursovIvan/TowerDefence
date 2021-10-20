using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Projectile
{
    protected float slowDuration;
    protected float slowPower;
    FireProjectile()
    {
        moveSpeed = 10;
        slowDuration = 2.0f;
        slowPower = 1.0f;
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
        target.GetComponent<Enemy>().startSlow(slowDuration, slowPower);
        Destroy(gameObject);
    }
}
