using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        gameObject.transform.position = cursorPos;
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}
