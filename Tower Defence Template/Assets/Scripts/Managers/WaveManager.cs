using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public listOfLevelWaves curList = new listOfLevelWaves();
    public GameObject enemyCanvas;
    public bool waveEnded = true;
    private IEnumerator coroutine;
    private float timeBetweenEnemies;

    [System.Serializable]
    public class listOfLevelWaves
    {
        public List<ListOfEnemyWave> list;
    }
    [System.Serializable]
    public class ListOfEnemyWave
    {
        public List<EnemyWave> list;
    }
    [System.Serializable]
    public struct EnemyWave 
    {
        public GameObject enemyType;
        public int enemyNumber;
    }
    private void Awake()
    {
        Instance = this;

    }
    public void launchWave(int waveCount)
    {
        timeBetweenEnemies = 0.4f;
        if ((waveCount + 1) % 10 == 0)
        {
            timeBetweenEnemies = 1.2f;
        }
        coroutine = enemyCreator(curList.list[GameManager.Instance.currentLevel - 1].list[waveCount].enemyNumber, curList.list[GameManager.Instance.currentLevel - 1].list[waveCount].enemyType);
        waveEnded = false;
        StartCoroutine(coroutine);
    }

    void createEnemy(GameObject abstractEnemy, int pN, int sortDown, int sortUp)
    {
        GameObject enemyInstance = Instantiate(abstractEnemy);
        enemyInstance.transform.position = GameObject.Find("Paths").transform.GetChild(GameManager.Instance.currentLevel - 1).GetChild(pN).GetChild(0).transform.position;
        enemyInstance.GetComponent<Enemy>().pathNum = pN;
        enemyInstance.GetComponent<Enemy>().sortingOrderDown = sortDown;
        enemyInstance.GetComponent<Enemy>().sortingOrderUp = sortUp;
        GameObject enemyCanvasInstance = Instantiate(enemyCanvas, enemyInstance.transform);
        enemyCanvasInstance.transform.position = new Vector3 (enemyInstance.transform.position.x, enemyInstance.GetComponent<SpriteRenderer>().bounds.max.y, 0);
    }
    private IEnumerator enemyCreator(int enemyCount, GameObject enemyT)
    {
        int i = 0;
        while (i < enemyCount)
        {
            createEnemy(enemyT, i % GameObject.Find("Paths").transform.GetChild(GameManager.Instance.currentLevel - 1).childCount, enemyCount - i, i - enemyCount);
            i++;
            if (i == enemyCount)
            {
                waveEnded = true;
            }
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }
    public void WaveStop()
    {
        StopAllCoroutines();
    }
}
