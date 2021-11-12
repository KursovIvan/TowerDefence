public class WizardProjectile : Projectile
{
    WizardProjectile()
    {
        moveSpeed = 6;
    }
    protected override void OnHitEnemy()
    {
        target.GetComponent<Enemy>().TakeMagicDamage(attackDamage);
        Destroy(gameObject);
    }
}
