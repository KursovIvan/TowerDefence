public class MagicBasicEnemy : BasicEnemy
{
    public float magicArmor;
    public override void TakeMagicDamage(float damage)
    {
        healthPoints -= damage - damage * magicArmor / 100;
        updateHPBar();
        isAlive();
    }
}
