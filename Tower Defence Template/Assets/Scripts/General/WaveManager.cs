using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public List<EnemyWave> listOfEnemies = new List<EnemyWave>();
    private IEnumerator coroutine;

    [Serializable]
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
        coroutine = enemyCreator(listOfEnemies[waveCount].enemyNumber, listOfEnemies[waveCount].enemyType);
        StartCoroutine(coroutine);
    }

    void createEnemy(GameObject abstractEnemy, int pN)
    {
        GameObject enemyInstance = Instantiate(abstractEnemy);
        enemyInstance.transform.position = GameObject.Find("Paths").transform.GetChild(pN).transform.GetChild(0).transform.position;
        enemyInstance.GetComponent<Enemy>().pathNum = pN;
    }
    private IEnumerator enemyCreator(float enemyCount, GameObject enemyT)
    {
        int i = 0;
        while (i < enemyCount)
        {
            createEnemy(enemyT, i % GameObject.Find("Paths").transform.childCount);
            i++;
            yield return new WaitForSeconds(0.4f);
        }
    }
    public void WaveStop()
    {
        StopAllCoroutines();
    }
}
