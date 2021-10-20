using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRange : MonoBehaviour
{
    private float ratio = 4.75f;
    public void ScaleRadius(float radius) 
    {
        gameObject.transform.localScale = new Vector3(radius * ratio, radius * ratio, radius * ratio);
    }
    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = cursorPos;
        if (FindObjectsOfType<MovingSprite>().Length == 0)
        {
            Destroy(gameObject);
        }
    }  
}
