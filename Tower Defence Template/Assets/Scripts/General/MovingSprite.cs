using UnityEngine;

public class MovingSprite : MonoBehaviour
{
    public TowerType linkedTower;
    public static MovingSprite Instance;
    private void Awake()
    {
           Instance = this;
    }
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector2(cursorPos.x, cursorPos.y - GetComponent<SpriteRenderer>().size.y / 4f);
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("RangeCircle"));
        }
    }
}
