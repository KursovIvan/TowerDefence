using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    FastEnemy()
    {
        moveSpeed = 4.0f;
        healthPoints = 30;
        gold = 20;
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void getWayPoints(int pN)
    {
        base.getWayPoints(pN);
    }
    protected override void Move()
    {
        base.Move();
    }
    protected override void DropGold()
    {
        base.DropGold();
    }
    public override void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            DropGold();
            Destroy(gameObject);
        }
    }
}
