using UnityEngine;

public class RangeCircle : MonoBehaviour
{
    private float ratio = 4.75f;
    public void ScaleRadius(float radius) 
    {
        gameObject.transform.localScale = new Vector3(radius * ratio, radius * ratio, radius * ratio);
    }
    private void Update()
    {
        if (FindObjectsOfType<MovingSprite>().Length != 0)
        {
            gameObject.transform.position = new Vector3(MovingSprite.Instance.transform.position.x, MovingSprite.Instance.transform.position.y + 0.4f, 0);
        }
    }  
}
