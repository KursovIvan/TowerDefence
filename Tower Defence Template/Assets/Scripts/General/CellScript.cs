using UnityEngine;

public class CellScript : MonoBehaviour
{
    public Color baseColor;
    public Color currentColor;
    public int orderInLayer;
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
            TowerInfo.Instance.TowerInfoReset();
            if (GetComponent<SpriteRenderer>().color == currentColor)
            {
                float spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
                float spriteSizeY = GetComponent<SpriteRenderer>().bounds.size.y;
                Vector3 slotToFill = new Vector3(transform.position.x + spriteSizeX / 2, transform.position.y - spriteSizeY, 0);
                Shop.Instance.createNewTower(slotToFill, MovingSprite.Instance.linkedTower, transform);
                HasTower = true;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
