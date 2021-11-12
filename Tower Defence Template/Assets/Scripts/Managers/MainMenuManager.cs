using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void onPlay()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void toMainMenu()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void onExitGame()
    {
        Application.Quit();
    }
}
