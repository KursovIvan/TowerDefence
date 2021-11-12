public class StealthEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        enemyTag = "Stealth";
    }
}
