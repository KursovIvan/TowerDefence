using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
    public GameObject StonePrefab;
    public GameObject CannonPrefab;
    public GameObject IcePrefab;
    public GameObject ShotgunPrefab;
    public GameObject BuffPrefab;
    public GameObject BallistaPrefab;
    public GameObject WizardPrefab;
    public GameObject TeslaPrefab;
    public GameObject PoisonPrefab;
    public GameObject OraclePrefab;
    public GameObject ItemPref;
    public Transform ItemGrid;

   [System.Serializable]
   public struct TowerCost
    {
        public Sprite towerSprite;
        public string towerName;
        public int towerPrice;
        public float radius;
        public TowerType towerType;
    }

    public List<TowerCost> towerCosts = new List<TowerCost>();

    private void Awake()
    {
        Instance = this;
        foreach(TowerCost tCost in towerCosts)
        {
            GameObject itemInstance = Instantiate(ItemPref);
            itemInstance.transform.SetParent(ItemGrid, false);
            itemInstance.GetComponent<ShopItem>().SetData(tCost.towerSprite, tCost.towerName, tCost.towerPrice, tCost.towerType, tCost.radius);
        }
    }
    public void createNewTower(Vector3 slotToFill, TowerType towerT, Transform parent)
    {
        if (parent.GetComponent<CellScript>().HasTower == false)
        {
            switch (towerT)
            {
                case TowerType.StoneTower:
                    Instantiate(StonePrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.CannonTower:
                    Instantiate(CannonPrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.IceTower:
                    Instantiate(IcePrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.ShotgunTower:
                    Instantiate(ShotgunPrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.BuffTower:
                    Instantiate(BuffPrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    break;
                case TowerType.BallistaTower:
                    Instantiate(BallistaPrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.WizardTower:
                    Instantiate(WizardPrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.TeslaTower:
                    Instantiate(TeslaPrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.PoisonTower:
                    Instantiate(PoisonPrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
                case TowerType.OracleTower:
                    Instantiate(OraclePrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    foreach (BuffTower buffTower in FindBuffTowers())
                    {
                        buffTower.GiveBuff();
                    }
                    break;
            }
        }
    }
    public int GetTowerPrice(TowerType towerType)
    {
        return (from towerCost in towerCosts where towerCost.towerType == towerType select towerCost.towerPrice).FirstOrDefault();
    }
    public List<BuffTower> FindBuffTowers()
    {
        List<BuffTower> curBuffTowers = new List<BuffTower>();
        foreach (BuffTower buffTower in FindObjectsOfType<BuffTower>())
        {
            curBuffTowers.Add(buffTower);
        }
        return curBuffTowers;
    }
}
