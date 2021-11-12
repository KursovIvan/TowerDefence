using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float rateOfFire;   
    public float attackDamage;
    public int upgradeCost;
    public int towerLevel;
    public int maxTowerLevel;
    public float buffValue;
    public string towerDescription;  
    public GameObject rangeCircle;
    public CircleCollider2D circleCollider;
    public Vector3 towerRangePoint;
    public List<GameObject> targetBuffer;
    public List<string> targetTags;   
    public Animator animator;  
    protected Vector3 shootPosition;
    protected float currentTime;
    

    protected virtual void Awake()
    {
        GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<CellScript>().orderInLayer + 10;
        circleCollider = gameObject.transform.GetChild(1).GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        shootPosition = gameObject.transform.GetChild(0).position;
        towerRangePoint = gameObject.transform.GetChild(1).position;     
        towerLevel = 1;
        maxTowerLevel = 3;
        buffValue = 1;
        targetBuffer = new List<GameObject>();
        targetTags = new List<string>();
    }
    protected virtual void Update()
    {
        currentTime += Time.deltaTime;
        if (shootIsEnable() && targetBuffer.Count != 0)
        {
            foreach (GameObject enemy in targetBuffer)
            {
                if (targetTags.Contains(enemy.tag))
                {
                    Shoot(enemy);
                    currentTime = 0;
                    break;
                }
            }   
        }
    }
    protected virtual void Shoot(GameObject Enemy) 
    { 
    }
    protected virtual bool shootIsEnable()
    {
        if (currentTime > rateOfFire)
        {
            return true;
        }
        return false;
    }
    public virtual void towerLevelUp()
    {
    }
    protected virtual void ShowTowerInfo()
    {
        TowerInfo.Instance.currentTower = this;
        TowerInfo.Instance.UpdateTowerInfoPanel();
    }
    protected virtual void ShowAttackRadius()
    {
        Destroy(GameObject.FindGameObjectWithTag("RangeCircle"));
        GameObject rangeCircleInstance = Instantiate(rangeCircle, towerRangePoint, Quaternion.identity, transform);
        rangeCircleInstance.GetComponent<RangeCircle>().ScaleRadius(circleCollider.radius);
    }
    protected virtual void OnMouseDown()
    {
        if (!GameManager.Instance.isPaused)
        {
            ShowTowerInfo();
            ShowAttackRadius();
        }
    }
}

public enum TowerType
{
    StoneTower,
    CannonTower,
    IceTower,
    ShotgunTower,
    BuffTower,
    BallistaTower,
    WizardTower,
    TeslaTower,
    PoisonTower,
    OracleTower
}