using UnityEngine;

public class IceTower : Tower
{
    public float slowPower;

    protected override void Awake()
    {
        base.Awake();
        attackDamage = 0;
        rateOfFire = 0;
        upgradeCost = 60;
        towerDescription = "Slows Enemies";
        slowPower = 20f;
        targetTags.Add("Enemy");
        targetTags.Add("FlyingEnemy");
    }
    protected override void Update()
    {
        if (targetBuffer.Count != 0)
        {
            foreach (GameObject enemy in targetBuffer)
            {
                if (targetTags.Contains(enemy.tag))
                {
                    enemy.GetComponent<Enemy>().GetSlow(slowPower);
                }
            }
        }
    }
    public void Slow(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().GetSlow(slowPower);
    }
    public void SlowOff(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().SlowOff(slowPower);
    }
    public override void towerLevelUp()
    {
        slowPower += 10f;
        towerLevel++;
        upgradeCost += 20;
        ShowAttackRadius();
    }
}
