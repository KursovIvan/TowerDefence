using UnityEngine;

public class WizardTower : Tower
{
    public GameObject wizardProjectilePrefab;

    protected override void Awake()
    {
        base.Awake();
        attackDamage = 135;
        rateOfFire = 1.8f;
        currentTime = rateOfFire;
        upgradeCost = 80;
        towerDescription = "Magic Damage \nAnti Air";
        targetTags.Add("Enemy");
        targetTags.Add("FlyingEnemy");
    }
    protected override void Shoot(GameObject Enemy)
    {
        if (Enemy != null)
        {
            GameObject projectileIns = Instantiate(wizardProjectilePrefab);
            projectileIns.transform.position = shootPosition;
            projectileIns.GetComponent<WizardProjectile>().target = Enemy.transform;
            projectileIns.GetComponent<WizardProjectile>().attackDamage = attackDamage;
        }
    }
    public override void towerLevelUp()
    {
        attackDamage *= 2.75f;
        towerLevel++;
        upgradeCost += 80;
        ShowAttackRadius();
    }
}
