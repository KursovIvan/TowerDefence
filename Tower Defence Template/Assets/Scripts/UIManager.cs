using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text txtGold;
    public Text txtWave;
    public Text txtLives;
    public Text txtLevel;

    void Awake() 
    {
        Instance = this;
    }
    private void UpdateTopBar()
    {
        txtGold.text = GameManager.Instance.goldNumber.ToString();
        txtWave.text = "Wave " + GameManager.Instance.waveCount + " / " + WaveManager.Instance.listOfEnemies.Count;
        txtLives.text = "Remaining lives " + GameManager.Instance.livesNumber.ToString();
        txtLevel.text = "Level " + GameManager.Instance.currentLevel;
    }
    void Update()
    {
        UpdateTopBar();
    }
    public void ShowPauseMenu()
    {

    }
}
