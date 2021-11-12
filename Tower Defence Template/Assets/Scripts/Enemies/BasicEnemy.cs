public class BasicEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        enemyTag = "Enemy";
    }
}
