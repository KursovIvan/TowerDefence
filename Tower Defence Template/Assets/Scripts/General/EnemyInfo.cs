using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    public static EnemyInfo Instance;
    public GameObject currentEnemy;

    private void Awake()
    {
        Instance = this;
    }
    public void UpdateEnemyInfo()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = currentEnemy.GetComponent<SpriteRenderer>().sprite;
        transform.GetChild(0).GetChild(1).GetComponent<Text>().text = currentEnemy.GetComponent<Enemy>().enemyName;
        transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "HP " + currentEnemy.GetComponent<Enemy>().healthPoints.ToString();
        transform.GetChild(0).GetChild(3).GetComponent<Text>().text = currentEnemy.GetComponent<Enemy>().enemyDescription;

        UIManager.Instance.enemyInfo.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.isPaused = true;
    }
    public void CloseEnemyInfo()
    {
        UIManager.Instance.enemyInfo.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.isPaused = false;
    }
}
