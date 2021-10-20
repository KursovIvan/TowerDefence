using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellScript : MonoBehaviour
{
    public Color baseColor;
    public Color currentColor;
    public GameObject rangeCircle;
    public GameObject rangeCircleInstance;
    public int orderInLayer;
    public float rangeRadius;
    public bool HasTower = false;

    private void OnMouseEnter()
    {
        if (!HasTower && FindObjectsOfType<MovingSprite>().Length != 0 && !GameManager.Instance.isPaused)
        {
            GetComponent<SpriteRenderer>().color = currentColor;
        }      
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = baseColor;
    }
    private void OnMouseDown()
    {
        if (!GameManager.Instance.isPaused)
        {
            Destroy(GameObject.FindGameObjectWithTag("RangeCircle"));
            if (GetComponent<SpriteRenderer>().color == currentColor)
            {
                float spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
                float spriteSizeY = GetComponent<SpriteRenderer>().bounds.size.y;
                Vector3 slotToFill = new Vector3(transform.position.x + spriteSizeX / 2, transform.position.y - spriteSizeY, 0);
                Shop.Instance.createNewTower(slotToFill, MovingSprite.Instance.linkedTower, transform);
                HasTower = true;
            }
            else if (HasTower && FindObjectsOfType<MovingSprite>().Length == 0)
            {
                float spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
                float spriteSizeY = GetComponent<SpriteRenderer>().bounds.size.y;
                Vector3 pos = new Vector3(transform.position.x + spriteSizeX / 2, transform.position.y - spriteSizeY, 0);
                GameObject rangeCircleInstance = Instantiate(rangeCircle, pos, Quaternion.identity, transform);
                rangeCircleInstance.GetComponent<StaticRange>().ScaleRadius(rangeRadius);
            }
        }
    }
}
