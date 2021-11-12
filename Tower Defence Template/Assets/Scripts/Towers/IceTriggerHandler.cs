using UnityEngine;

public class IceTriggerHandler : MonoBehaviour
{
    public IceTower attachedTower;
    public void Awake()
    {
        attachedTower = GetComponentInParent<IceTower>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            attachedTower.targetBuffer.Add(collision.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (attachedTower.targetBuffer.Count != 0)
        {
            attachedTower.targetBuffer.Remove(collision.gameObject);
            attachedTower.SlowOff(collision.gameObject);
        }
    }
}
