using UnityEngine;

public class BallistaProjectile : Projectile
{
    BallistaProjectile()
    {
        moveSpeed = 12;
    }
    protected override void Move()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
            if (transform.position - targetPos != Vector3.zero)
            {
                var newRotation = Quaternion.LookRotation(transform.position - targetPos, Vector3.forward);
                newRotation.x = 0.0f;
                newRotation.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 64);
            }
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
    protected override void OnHitEnemy()
    {
        target.GetComponent<Enemy>().TakeDamage(attackDamage);
        Destroy(gameObject);
    }
}
