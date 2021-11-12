using UnityEngine;

public class CannonTower : Tower
{
    public GameObject cannonProjectilePrefab;

    protected override void Awake()
    {
        base.Awake();
        attackDamage = 70;
        rateOfFire = 2f;
        currentTime = rateOfFire;
        upgradeCost = 50;
        towerDescription = "AOE Explosion";
        targetTags.Add("Enemy");
    }
    protected override void Shoot(GameObject Enemy)
    {
        if (Enemy != null)
        {
            animator.SetTrigger("Shoot");
            GameObject projectileIns = Instantiate(cannonProjectilePrefab);
            projectileIns.transform.position = shootPosition;
            projectileIns.GetComponent<CannonProjectile>().target = Enemy.transform;
            projectileIns.GetComponent<CannonProjectile>().attackDamage = attackDamage;
        }
    }
    public override void towerLevelUp()
    { 
        attackDamage *= 2.5f;
        towerLevel++;
        upgradeCost += 70;
        ShowAttackRadius();
    }
}
