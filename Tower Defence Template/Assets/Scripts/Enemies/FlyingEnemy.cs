public class FlyingEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        enemyTag = "FlyingEnemy";
    }
}
