using System.Linq;
using UnityEngine;

public class ShotgunTower : Tower
{
    protected bool isShoot;
    protected override void Awake()
    {
        base.Awake();
        attackDamage = 35;
        rateOfFire = 1f;
        currentTime = rateOfFire;
        upgradeCost = 35;
        towerDescription = "Multitarget Damage";
        targetTags.Add("Enemy");
        isShoot = false;
    }
    protected override void Update()
    {
        currentTime += Time.deltaTime;

        if (shootIsEnable() && targetBuffer.Count != 0)
        {
            foreach (GameObject enemy in targetBuffer.ToList())
            {
                if (targetTags.Contains(enemy.tag))
                {
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunTowerShoot"))
                    {
                        animator.SetTrigger("Shoot");
                    }
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                    isShoot = true;
                }
            }
            if (isShoot)
            {
                currentTime = 0;
                isShoot = false;
            }
        }    
    }
    public override void towerLevelUp()
    {
        attackDamage *= 1.75f;
        rateOfFire /= 1.15f;
        towerLevel++;
        upgradeCost += 50;
        ShowAttackRadius();
    }
}
