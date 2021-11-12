using UnityEngine;

public class PoisonTower : Tower
{
    public GameObject poisonProjectilePrefab;
    protected Vector3 particlePosition;

    protected override void Awake()
    {
        base.Awake();
        particlePosition = gameObject.transform.GetChild(2).position;
        attackDamage = 45;
        rateOfFire = 0.8f;
        currentTime = rateOfFire;
        upgradeCost = 60;
        towerDescription = "Poison \nAnti Air";
        targetTags.Add("Enemy");
        targetTags.Add("FlyingEnemy");
    }
    protected override void Shoot(GameObject Enemy)
    {
        if (Enemy != null)
        {
            GameObject projectileIns = Instantiate(poisonProjectilePrefab);
            projectileIns.transform.position = shootPosition;
            projectileIns.GetComponent<PoisonProjectile>().target = Enemy.transform;
            projectileIns.GetComponent<PoisonProjectile>().attackDamage = attackDamage;
            ParticleManager.Instance.PoisonSplashParticle(particlePosition, gameObject.GetComponent<SpriteRenderer>().sortingOrder);
        }
    }
    public override void towerLevelUp()
    {
        attackDamage *= 1.85f;
        rateOfFire /= 1.1f;
        towerLevel++;
        upgradeCost += 75;
        ShowAttackRadius();
    }
}
