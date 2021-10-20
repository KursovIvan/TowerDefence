using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
    public GameObject StonePrefab;
    public GameObject FirePrefab;
    public GameObject ItemPref;
    public Transform ItemGrid;

   [Serializable]
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
                    break;
                case TowerType.FireTower:
                    Instantiate(FirePrefab, slotToFill, Quaternion.identity, parent);
                    GameManager.Instance.goldNumber -= GetTowerPrice(towerT);
                    break;
            }
        }
    }
    public int GetTowerPrice(TowerType towerType)
    {
        return (from towerCost in towerCosts where towerCost.towerType == towerType select towerCost.towerPrice).FirstOrDefault();
    }
}
