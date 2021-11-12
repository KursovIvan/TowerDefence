using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public void loadGameLevel()
    {
        CurrentLevel.curLvl = int.Parse(transform.GetChild(0).GetComponent<Text>().text);
        SceneManager.LoadScene("GameScreen");
    }
}
