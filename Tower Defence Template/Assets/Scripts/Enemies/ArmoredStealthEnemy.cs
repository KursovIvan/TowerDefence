public class ArmoredStealthEnemy : StealthEnemy
{
    public float armor;
    public override void TakeDamage(float damage)
    {
        healthPoints -= damage - damage * armor / 100;
        updateHPBar();
        isAlive();
    }
}
