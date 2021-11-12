using UnityEngine;

public class StoneTower : Tower
{
    public GameObject stoneProjectilePrefab;

    protected override void Awake()
    {
        base.Awake();
        attackDamage = 39;
        rateOfFire = 0.65f;
        currentTime = rateOfFire;
        upgradeCost = 30;
        targetTags.Add("Enemy");
    }
    protected override void Shoot(GameObject Enemy)
    {
        if (Enemy != null)
        {
            GameObject projectileIns = Instantiate(stoneProjectilePrefab);
            projectileIns.transform.position = shootPosition;
            projectileIns.GetComponent<StoneProjectile>().target = Enemy.transform;
            projectileIns.GetComponent<StoneProjectile>().attackDamage = attackDamage;
        }
    }
    public override void towerLevelUp()
    {
        attackDamage = attackDamage * 1.5f;
        rateOfFire = rateOfFire / 1.2f;
        towerLevel++;
        upgradeCost += 40;
        ShowAttackRadius();
    }
}
