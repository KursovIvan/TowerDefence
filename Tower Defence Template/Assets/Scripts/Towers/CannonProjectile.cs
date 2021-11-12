using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : Projectile
{
    protected float explosionRadius;

    CannonProjectile()
    {
        moveSpeed = 10;
        explosionRadius = 1.2f;
    }
    protected override void OnHitEnemy()
    {
        foreach (GameObject enemy in GetEnemiesInExplosionRange())
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        ParticleManager.Instance.ExplosionParticle(transform.position);
        Destroy(gameObject);
    }
    protected List<GameObject> GetEnemiesInExplosionRange()
    {
        List<GameObject> enemiesInRange = new List<GameObject>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= explosionRadius)
            {
                enemiesInRange.Add(enemy);
            }
        }
        return enemiesInRange;
    }
}
