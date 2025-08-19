using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainTitle;
    public GameObject startButton;
    public GameObject levelButton;
    public GameObject quitButton;
    public GameObject lvlSelector;

    private void Awake()
    {
      Application.targetFrameRate = 60;

      lvlSelector.SetActive(false);
    }
    
    public void LvlSelect()
    {
       mainTitle.SetActive(false);
       startButton.SetActive(false);
       levelButton.SetActive(false);
       quitButton.SetActive(false);
       
       lvlSelector.SetActive(true);
    }

    public void Back()
    {
       mainTitle.SetActive(true);
       startButton.SetActive(true);
       levelButton.SetActive(true);
       quitButton.SetActive(true);
       
       lvlSelector.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GreenGreens()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void CandyMountains()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
