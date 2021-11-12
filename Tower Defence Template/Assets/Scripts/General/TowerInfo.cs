using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour
{
    public static TowerInfo Instance;
    public Tower currentTower = null;

    private void Awake()
    {
        Instance = this;
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(false);
    }

    public void UpdateTowerInfoPanel() 
    {
        transform.GetChild(5).gameObject.SetActive(true);
        transform.GetChild(7).gameObject.SetActive(true);
        if (currentTower.TryGetComponent(out IceTower iceTower))
        {
            transform.GetChild(0).GetComponent<Text>().text = "Slow Power " + iceTower.slowPower.ToString("#") + "%";
            transform.GetChild(1).GetComponent<Text>().text = null;
            transform.GetChild(2).GetComponent<Text>().text = "Range " + currentTower.circleCollider.radius.ToString("0.00");
        }
        else if (currentTower.TryGetComponent(out BuffTower buffTower))
        {
            transform.GetChild(0).GetComponent<Text>().text = "Buff " + ((buffTower.buffValue - 1) * 100).ToString("#") + "%";
            transform.GetChild(1).GetComponent<Text>().text = null;
            transform.GetChild(2).GetComponent<Text>().text = "Range " + currentTower.circleCollider.radius.ToString("0.00");
        }
        else if (currentTower.TryGetComponent(out OracleTower oracleTower))
        {
            transform.GetChild(0).GetComponent<Text>().text = null;
            transform.GetChild(1).GetComponent<Text>().text = null;
            transform.GetChild(2).GetComponent<Text>().text = "Range " + currentTower.circleCollider.radius.ToString("0.00");
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = "Damage " + currentTower.attackDamage.ToString("#");
            transform.GetChild(1).GetComponent<Text>().text = "Rate of Fire " + (1 / currentTower.rateOfFire).ToString("0.00");
            transform.GetChild(2).GetComponent<Text>().text = "Range " + currentTower.circleCollider.radius.ToString("0.00");
        }
        transform.GetChild(3).GetComponent<Text>().text = currentTower.towerDescription;
        if (currentTower.towerLevel < currentTower.maxTowerLevel)
        {
            transform.GetChild(4).GetComponent<Text>().text = currentTower.upgradeCost.ToString();
            transform.GetChild(5).GetComponent<Button>().interactable = true;
            transform.GetChild(6).GetComponent<Text>().text = "Level " + currentTower.towerLevel.ToString();
        } else
        {
            transform.GetChild(4).GetComponent<Text>().text = null;
            transform.GetChild(5).GetComponent<Button>().interactable = false;
            transform.GetChild(6).GetComponent<Text>().text = "Max Level ";
        }
    }
    public void UpgradeTower()
    {
        if (GameManager.Instance.goldNumber >= currentTower.upgradeCost)
        {
            GameManager.Instance.goldNumber -= currentTower.upgradeCost;
            currentTower.towerLevelUp();
            ParticleManager.Instance.UpgradeParticle(currentTower.towerRangePoint, currentTower.gameObject.GetComponent<SpriteRenderer>().sortingOrder);
            UpdateTowerInfoPanel();                     
        }      
    }
    public void TowerInfoReset()
    {
        transform.GetChild(0).GetComponent<Text>().text = null;
        transform.GetChild(1).GetComponent<Text>().text = null;
        transform.GetChild(2).GetComponent<Text>().text = null;
        transform.GetChild(3).GetComponent<Text>().text = null;
        transform.GetChild(4).GetComponent<Text>().text = null;
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).GetComponent<Text>().text = null;
        transform.GetChild(7).gameObject.SetActive(false);
        currentTower = null;
    }
    public void DeleteTower()
    {
        currentTower.gameObject.transform.parent.GetComponent<CellScript>().HasTower = false;
        currentTower.gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
        Destroy(currentTower.gameObject);
        TowerInfoReset();
    }
}