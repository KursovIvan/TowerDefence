using UnityEngine;

public class OracleTriggerHandler : MonoBehaviour
{
    public OracleTower attachedTower;
    public void Awake()
    {
        attachedTower = GetComponentInParent<OracleTower>();
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
            if (collision.GetComponent<StealthEnemy>())
            {
                attachedTower.RevealOff(collision.gameObject);
                if (attachedTower.targetBuffer.Count == 0)
                {
                    attachedTower.animator.SetTrigger("VisionOff");
                }
            }          
        }
    }
}
