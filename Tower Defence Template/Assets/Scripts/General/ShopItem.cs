using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Color baseColor;
    public Color currentColor;
    public Color blockColor;
    public TowerType linkedTower;
    public GameObject movingTowerSpritePref;
    public GameObject RangeCircle;
    public float radius;
    private int towerCost;

    public void SetData(Sprite Logo, string Name, int Cost, TowerType linkedT, float rangeRadius)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Logo;
        transform.GetChild(0).GetComponent<Image>().SetNativeSize();
        transform.GetChild(1).GetComponent<Text>().text = Name;
        transform.GetChild(2).GetComponent<Text>().text = Cost.ToString();
        linkedTower = linkedT;
        radius = rangeRadius;
        towerCost = Cost;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!GameManager.Instance.isPaused)
        {
            if (FindObjectsOfType<MovingSprite>().Length == 0 && IsAfford(towerCost))
            {
                GetComponent<Image>().color = currentColor;
            }
            else
            {
                GetComponent<Image>().color = blockColor;
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = baseColor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.Instance.isPaused)
        {
            Destroy(GameObject.FindGameObjectWithTag("RangeCircle"));
            TowerInfo.Instance.TowerInfoReset();
            if (GetComponent<Image>().color == currentColor)
            {              
                GameObject movingSpriteInstance = Instantiate(movingTowerSpritePref, gameObject.transform);
                movingSpriteInstance.transform.GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetComponent<Image>().sprite;
                movingSpriteInstance.GetComponent<MovingSprite>().linkedTower = linkedTower;
                GameObject movingRangeCircle = Instantiate(RangeCircle);
                movingRangeCircle.GetComponent<RangeCircle>().ScaleRadius(radius);
                GetComponent<Image>().color = blockColor;
            }
        }
    }
    public bool IsAfford(int towerPrice)
    {
        return (GameManager.Instance.goldNumber >= towerPrice);
    }
}