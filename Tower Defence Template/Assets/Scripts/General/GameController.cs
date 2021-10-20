using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{  
    protected Queue<GameObject> enemiesBuffer;
    protected float rateOfFire;
    protected float currentTime = 0;
    protected float attackRadius;
    protected int attackDamage;

    protected virtual void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<CellScript>().orderInLayer;
        attackRadius = GetComponent<CircleCollider2D>().radius;
        transform.parent.GetComponent<CellScript>().rangeRadius = attackRadius;
    }
    protected virtual void Update()
    {
        currentTime += Time.deltaTime;
        if (shootIsEnable())
        {
            if (enemiesBuffer.Count != 0)
            {
                Shoot(enemiesBuffer.Peek());
                currentTime = 0;
            }
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemiesBuffer.Enqueue(collider.gameObject);
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemiesBuffer.Dequeue();
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
}

public abstract class Projectile : MonoBehaviour
{
    public Transform target;
    public int attackDamage;
    protected float moveSpeed;

    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {             
                OnHitEnemy();              
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    protected abstract void OnHitEnemy();
}
public enum TowerType
{
    StoneTower,
    FireTower
}

public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int pathNum;
    protected List<GameObject> currentPath;
    protected bool coroutineRunning = false;   
    protected int healthPoints;
    protected int wayIndex = 0;
    protected int gold;

    protected virtual void Start()
    {
        getWayPoints(pathNum);
    }
    protected virtual void getWayPoints(int pN)
    {
        currentPath = new List<GameObject>(GameObject.Find("Paths").transform.GetChild(pN).GetComponent<Path>().pathWaypoints);
    }
    protected virtual void  Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        Vector3 target = currentPath[wayIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (wayIndex < currentPath.Count - 1)
            {
                wayIndex++;
            }
            else 
            {
                Destroy(gameObject);
                GameManager.Instance.OnEnemyEscape();
            }
        }
    }
    public abstract void TakeDamage(int damage);

    public virtual void startSlow(float slowDuration, float slowPower)
    {
        if (!coroutineRunning)
        {
            StartCoroutine(GetSlow(slowDuration, slowPower));
        }       
    }
    protected virtual void DropGold()
    {
        GameManager.Instance.goldNumber += gold;
    }
    protected virtual IEnumerator GetSlow(float duration, float value)
    {
        coroutineRunning = true;
        moveSpeed -= value;
        yield return new WaitForSeconds(duration);
        moveSpeed += value;
        coroutineRunning = false; 
    }
}
public class GameController : MonoBehaviour
{
    

}
