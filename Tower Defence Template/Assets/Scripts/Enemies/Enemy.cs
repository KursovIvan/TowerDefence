using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int pathNum;
    public int sortingOrderUp;
    public int sortingOrderDown;
    public int gold;
    public float healthPoints;
    public float maxHealthPoints;
    public string enemyName;
    public string enemyDescription;
    protected Image hpBar;
    protected List<GameObject> currentPath;
    public string enemyTag;
    protected float currentSlowPower;
    protected Coroutine poisonDOT;
    protected float currentPoisonDamage;
    public int wayIndex;
    public Animator animator;

    protected virtual void Awake()
    {
        wayIndex = 0;
        animator = GetComponent<Animator>();
    }
    protected virtual void Start()
    {
        getWayPoints(pathNum);     
        maxHealthPoints = healthPoints;
        hpBar = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        currentPoisonDamage = 0;
        currentSlowPower = 0;
        gameObject.transform.tag = enemyTag;
    }
    protected virtual void getWayPoints(int pN)
    {     
        currentPath = new List<GameObject>(GameObject.Find("Paths").transform.GetChild(GameManager.Instance.currentLevel - 1).GetChild(pN).GetComponent<Path>().pathWaypoints);      
    }
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        Vector3 target = currentPath[wayIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
        if (Vector3.Distance(transform.position, target) == 0)
        {
            if (wayIndex < currentPath.Count - 1)
            {
                wayIndex++;
                target = currentPath[wayIndex].transform.position;
                if (gameObject.transform.position.x < target.x)
                {
                    animator.SetInteger("MovingDirection", 1);
                    GetComponent<SpriteRenderer>().sortingOrder = sortingOrderDown;
                }
                else if (gameObject.transform.position.x > target.x)
                {
                    animator.SetInteger("MovingDirection", 2);
                    GetComponent<SpriteRenderer>().sortingOrder = sortingOrderDown;
                }
                else if (gameObject.transform.position.y > target.y)
                {
                    animator.SetInteger("MovingDirection", 0);
                    GetComponent<SpriteRenderer>().sortingOrder = sortingOrderDown;
                }
                else if (gameObject.transform.position.y < target.y)
                {
                    animator.SetInteger("MovingDirection", 3);
                    GetComponent<SpriteRenderer>().sortingOrder = sortingOrderUp;
                }
            }
            else
            {
                Destroy(gameObject);
                GameManager.Instance.OnEnemyEscape();
            }
        }
    }
    public virtual void TakeDamage(float damage)
    {
        healthPoints -= damage;
        updateHPBar();
        isAlive();
        
    }
    protected virtual void isAlive()
    {
        if (healthPoints <= 0)
        {
            DropGold();
            Destroy(gameObject);
        }
    }

    public virtual void GetSlow(float slowPower)
    {
        if (slowPower > currentSlowPower)
        {
            SlowOff(currentSlowPower);
            currentSlowPower = slowPower;
            moveSpeed -= moveSpeed * slowPower / 100;
            ParticleManager.Instance.FrozenParticle(gameObject.transform.position, gameObject.transform);
        }
    }
    public virtual void SlowOff(float slowPower)
    {
        if (slowPower == currentSlowPower)
        {
            moveSpeed = moveSpeed * 100 / (100 - slowPower);
            currentSlowPower = 0;
        }
    }
    protected virtual void DropGold()
    {
        GameManager.Instance.goldNumber += gold;
    }
    protected virtual void updateHPBar()
    {
        hpBar.fillAmount = healthPoints / maxHealthPoints;
    }
    public virtual void TakeMagicDamage(float damage)
    {
        healthPoints -= damage;
        updateHPBar();
        isAlive();
    }
    public virtual void startPoisoned(float poisonDuration, float poisonPower)
    {
        if (poisonPower > currentPoisonDamage)
        {
            if (poisonDOT != null)
            {
                StopCoroutine(poisonDOT);
            }
            currentPoisonDamage = poisonPower;
            poisonDOT = StartCoroutine(GetPoisoned(poisonDuration, poisonPower));
        }
    }
    protected virtual IEnumerator GetPoisoned(float duration, float value)
    {
        int i = 0;
        while (i < duration*2)
        {
            yield return new WaitForSeconds(0.5f);
            ParticleManager.Instance.PoisonDOTParticle(gameObject.transform.position, gameObject.transform);
            healthPoints -= value;
            updateHPBar();
            isAlive();
            i++;        
        }
        currentPoisonDamage = 0;
    }
}