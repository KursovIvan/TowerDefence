using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    public GameObject fireProjectilePrefab;
    FireTower()
    {
        enemiesBuffer = new Queue<GameObject>();
        attackDamage = 10;
        rateOfFire = 1.5f;
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
    protected override void OnTriggerExit2D(Collider2D collider)
    {
        base.OnTriggerExit2D(collider);
    }
    protected override void Shoot(GameObject Enemy)
    {
        if (Enemy != null)
        {
            GameObject projectileIns = Instantiate(fireProjectilePrefab);
            projectileIns.transform.position = gameObject.transform.position;
            projectileIns.GetComponent<FireProjectile>().target = Enemy.transform;
            projectileIns.GetComponent<FireProjectile>().attackDamage = attackDamage;
        }
    }
    protected override bool shootIsEnable()
    {
        return base.shootIsEnable();
    }
}
