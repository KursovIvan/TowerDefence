public class MagicFlyingEnemy : FlyingEnemy
{
    public float magicArmor;
    public override void TakeMagicDamage(float damage)
    {
        healthPoints -= damage - damage * magicArmor / 100;
        updateHPBar();
        isAlive();
    }
}
