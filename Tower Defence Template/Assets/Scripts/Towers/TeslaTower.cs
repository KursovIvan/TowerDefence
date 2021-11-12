using UnityEngine;

public class TeslaTower : Tower
{
    public GameObject teslaProjectilePrefab;

    protected override void Awake()
    {
        base.Awake();
        attackDamage = 25;
        rateOfFire = 0.7f;
        currentTime = rateOfFire;
        upgradeCost = 65;
        towerDescription = "Magic Chain Damage";
        targetTags.Add("Enemy");
    }
    protected override void Shoot(GameObject Enemy)
    {
        if (Enemy != null)
        {
            GameObject projectileIns = Instantiate(teslaProjectilePrefab);
            projectileIns.transform.position = shootPosition;
            projectileIns.GetComponent<TeslaProjectile>().target = Enemy.transform;
            projectileIns.GetComponent<TeslaProjectile>().attackDamage = attackDamage;
            ParticleManager.Instance.ElecticParticle(shootPosition, gameObject.GetComponent<SpriteRenderer>().sortingOrder);
        }
    }
    public override void towerLevelUp()
    {
        attackDamage *= 1.3f;
        rateOfFire /= 1.1f;
        towerLevel++;
        upgradeCost += 50;
        ShowAttackRadius();
    }
}
