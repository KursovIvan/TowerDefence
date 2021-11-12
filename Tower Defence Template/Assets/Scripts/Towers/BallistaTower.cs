using UnityEngine;

public class BallistaTower : Tower
{
    public GameObject ballistaProjectilePrefab;

    protected override void Awake()
    {
        base.Awake();
        attackDamage = 70;
        rateOfFire = 1f;
        currentTime = rateOfFire;
        upgradeCost = 50;
        towerDescription = "Anti Air";
        targetTags.Add("Enemy");
        targetTags.Add("FlyingEnemy");
    }
    protected override void Shoot(GameObject Enemy)
    {
        if (Enemy != null)
        {
            animator.SetTrigger("Shoot");
            GameObject projectileIns = Instantiate(ballistaProjectilePrefab);
            projectileIns.transform.position = shootPosition;
            projectileIns.GetComponent<BallistaProjectile>().target = Enemy.transform;
            projectileIns.GetComponent<BallistaProjectile>().attackDamage = attackDamage;
        }
    }
    public override void towerLevelUp()
    {
        attackDamage = attackDamage * 1.85f;
        rateOfFire = rateOfFire / 1.1f;
        towerLevel++;
        upgradeCost += 60;
        ShowAttackRadius();
    }
}
