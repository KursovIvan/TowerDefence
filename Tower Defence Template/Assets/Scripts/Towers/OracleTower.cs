using UnityEngine;

public class OracleTower : Tower
{
    protected override void Awake()
    {
        base.Awake();
        attackDamage = 0;
        rateOfFire = 0;
        upgradeCost = 60;
        towerDescription = "Reveals enemies";
        targetTags.Add("Stealth");
    }
    protected override void Update()
    {
        if (targetBuffer.Count != 0)
        {
            foreach (GameObject enemy in targetBuffer)
            {
                if (targetTags.Contains(enemy.tag))
                {
                    Reveal(enemy);
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("OracleTowerIdle"))
                    {
                        animator.SetTrigger("VisionOn");
                    }
                }
            }
        }
    }
    public void Reveal(GameObject stealthEnemy)
    {
        stealthEnemy.tag = "Enemy";
        stealthEnemy.GetComponent<SpriteRenderer>().color += new Color (0, 0, 0, 1f);
    }
    public void RevealOff(GameObject stealthEnemy)
    {
        stealthEnemy.tag = "Stealth";
        stealthEnemy.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 1f);
    }
    public override void towerLevelUp()
    {
        circleCollider.radius = ((circleCollider.radius / buffValue) + 0.3f) * buffValue;
        towerLevel++;
        upgradeCost += 40;
        ShowAttackRadius();
    }
}
