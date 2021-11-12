using System.Collections.Generic;
using UnityEngine;

public class BuffTower : Tower
{
    protected float radiusValue;
    protected override void Awake()
    {
        base.Awake();
        attackDamage = 0;
        rateOfFire = 0;
        upgradeCost = 50;
        towerDescription = "Buffs Nearby Towers";
        buffValue = 1.1f;
        radiusValue = 1.083f;
        targetTags.Add("Tower");
    }
    public void Start()
    {
        GiveBuff();
    }
    public void GiveBuff()
    {
        foreach (Tower tower in GetTowersInBuffRange())
        {
            if (buffValue > tower.buffValue)
            {              
                tower.attackDamage =  tower.attackDamage / tower.buffValue * buffValue;
                tower.rateOfFire = tower.rateOfFire * tower.buffValue / buffValue;
                tower.circleCollider.radius = tower.circleCollider.radius / tower.buffValue * buffValue; 
                if (tower.circleCollider.radius > 3.6f)
                {
                    tower.circleCollider.radius = 3.6f;
                }
                tower.buffValue = buffValue;
                ParticleManager.Instance.BuffParticle(tower.gameObject.transform.position, tower.gameObject.GetComponent<SpriteRenderer>().sortingOrder);
            }
        }
    }
    protected List<Tower> GetTowersInBuffRange()
    {
        List<Tower> towersInRange = new List<Tower>();
        foreach (Tower tower in FindObjectsOfType<Tower>())
        {
            if (Vector3.Distance(towerRangePoint, tower.gameObject.transform.GetChild(1).position) <= circleCollider.radius && !tower.GetComponent<BuffTower>())
            {
                towersInRange.Add(tower);
            }
        }
        return towersInRange;
    }
    public override void towerLevelUp()
    {
        buffValue += 0.1f;
        towerLevel++;
        upgradeCost += 30;
        ShowAttackRadius();
        GiveBuff();
    }
    private void OnDestroy()
    {
        foreach (Tower tower in GetTowersInBuffRange())
        {
            if (tower.buffValue == buffValue)
            {
                tower.attackDamage /= buffValue;
                tower.rateOfFire *= buffValue;
                if (tower.circleCollider.radius == 3.6f)
                {
                    tower.circleCollider.radius *= radiusValue;
                }
                tower.circleCollider.radius /= buffValue;
                tower.buffValue = 1;
            }
        }
        foreach (BuffTower buffTower in Shop.Instance.FindBuffTowers())
        {
            buffTower.GiveBuff();
        }
    }
}
