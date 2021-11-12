using System.Collections.Generic;
using UnityEngine;

public class TeslaProjectile : Projectile
{
    protected float chainRadius;
    protected int chainNumber;
    protected List<GameObject> previousTargets;
    TeslaProjectile()
    {
        previousTargets = new List<GameObject>();
        moveSpeed = 17;
        chainRadius = 1f;
    }

    protected override void OnHitEnemy()
    {       
        target.GetComponent<Enemy>().TakeMagicDamage(attackDamage);
        previousTargets.Add(target.gameObject);
        target = GetEnemieInChainRange();
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
    protected Transform GetEnemieInChainRange()
    {
        GameObject enemieInRange = null;
        bool isFind = false;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= chainRadius && !previousTargets.Contains(enemy))
            {
                enemieInRange = enemy;
                isFind = true;
            }
        }
        if (!isFind)
        {
            return null;
        }
        return enemieInRange.transform;
    }
}
