using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int livesNumber = 3;
    public int goldNumber = 100;
    public int waveCount = 0;
    public string currentLevel;
    public bool isPaused = false;
    private float currentTime = 0;
    private float timeBeetwenWaves = 6.0f;
    private bool gameOver = false;

    private void Awake()
    {
        Instance = this;
        currentLevel = "1";
    }
    private void Start()
    {
        LevelGenerator.Instance.createLevel(currentLevel);
    }
    private void Update()
    {
        if (!gameOver)
        {
            if (waveCount == WaveManager.Instance.listOfEnemies.Count && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) 
            {
                OnGameWin();
            }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                currentTime += Time.deltaTime;
                if (waveCount < WaveManager.Instance.listOfEnemies.Count && currentTime > timeBeetwenWaves)
                {
                    WaveManager.Instance.launchWave(waveCount);
                    waveCount++;
                    currentTime = 0;
                }
            }
        }
    } 
    void OnGameWin()
    {
        gameOver = true;
    }
    public void OnEnemyEscape()
    {
        livesNumber--;
        if (livesNumber <= 0)
        {
            OnGameLose();
        }
    }
    void OnGameLose()
    {
        gameOver = true;
        WaveManager.Instance.WaveStop();
        PauseGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }
}
