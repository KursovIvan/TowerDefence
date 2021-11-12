using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Transform target;
    public float attackDamage;
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