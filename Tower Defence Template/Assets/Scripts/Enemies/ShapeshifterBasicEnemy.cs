using UnityEngine;

public class ShapeshifterBasicEnemy : MagicBasicEnemy
{
    public GameObject shapeshiftPrefab;
    public GameObject enemyCanvas;

    protected override void isAlive()
    {
        if (healthPoints <= 0)
        {
            DropGold();
            Shapeshift();
            Destroy(gameObject);
        }
    }
    protected void Shapeshift()
    {
        GameObject shapeshift = Instantiate(shapeshiftPrefab);
        shapeshift.GetComponent<Enemy>().wayIndex = gameObject.GetComponent<Enemy>().wayIndex;
        shapeshift.transform.position = gameObject.transform.position;
        shapeshift.GetComponent<Enemy>().pathNum = gameObject.GetComponent<Enemy>().pathNum;     
        shapeshift.GetComponent<Enemy>().animator.SetInteger("MovingDirection", animator.GetInteger("MovingDirection"));
        shapeshift.GetComponent<Enemy>().sortingOrderDown = sortingOrderDown;
        shapeshift.GetComponent<Enemy>().sortingOrderUp = sortingOrderUp;
        GameObject enemyCanvasInstance = Instantiate(enemyCanvas, shapeshift.transform);
        enemyCanvasInstance.transform.position = new Vector3(shapeshift.transform.position.x, shapeshift.GetComponent<SpriteRenderer>().bounds.max.y, 0);
    }
}
