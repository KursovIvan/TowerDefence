using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentLevel;
    public int livesNumber;
    public int goldNumber;
    public int waveCount;
    public bool isPaused;
    private float currentTime = 0;
    public float timeBeetwenWaves = 5.0f;
    private bool gameOver = false;
    private bool clearBonus = false;

    private void Awake()
    {       
        Instance = this;
        isPaused = false;
        Time.timeScale = 1;
        Instance.currentLevel = CurrentLevel.curLvl;
        timeBeetwenWaves = 5.0f;
        waveCount = 0;
        goldNumber = 50;
        livesNumber = 20;

    }
    private void Start()
    {      
        LevelGenerator.Instance.createLevel(currentLevel.ToString());
        GameObject.Find("Paths").transform.GetChild(Instance.currentLevel - 1).gameObject.SetActive(true);
    }
    private void Update()
    {
        if (!gameOver)
        {
            if (!isPaused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                if (waveCount == WaveManager.Instance.curList.list[Instance.currentLevel - 1].list.Count && WaveManager.Instance.waveEnded && FindObjectsOfType<Enemy>().Length == 0)
                {
                    OnGameWin();
                }
                if (FindObjectsOfType<Enemy>().Length == 0 && WaveManager.Instance.waveEnded)
                {
                    currentTime += Time.deltaTime;
                    if (waveCount < WaveManager.Instance.curList.list[Instance.currentLevel - 1].list.Count)
                    {
                        if (EnemyInfo.Instance.currentEnemy != WaveManager.Instance.curList.list[currentLevel - 1].list[waveCount].enemyType)
                        {
                            EnemyInfo.Instance.currentEnemy = WaveManager.Instance.curList.list[currentLevel - 1].list[waveCount].enemyType;
                            EnemyInfo.Instance.UpdateEnemyInfo();
                            if (clearBonus)
                            {
                                GetClearBonus();
                            }
                        }
                        if (currentTime > timeBeetwenWaves)
                        {
                            clearBonus = true;
                            WaveManager.Instance.launchWave(waveCount);
                            waveCount++;
                            currentTime = 0;
                        }                    
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                DepauseGame();              
            }
        }
    } 
    void OnGameWin()
    {
        gameOver = true;
        PauseGame();
        UIManager.Instance.victoryScreen.SetActive(true);
    }
    public void OnEnemyEscape()
    {
        clearBonus = false;
        if (livesNumber > 0)
        {
            livesNumber--;
        }
        if (livesNumber == 0)
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
        UIManager.Instance.pauseMenu.SetActive(true);
        if (gameOver)
        {
            UIManager.Instance.pauseMenu.transform.GetChild(0).GetChild(0).GetComponent<Button>().interactable = false;
        }
    }
    public void DepauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        UIManager.Instance.pauseMenu.SetActive(false);
        UIManager.Instance.enemyInfo.SetActive(false);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void GetClearBonus()
    {
        GameManager.Instance.goldNumber += 5 * waveCount;
    }
}
