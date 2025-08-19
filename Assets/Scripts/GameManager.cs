using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text highscoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject gameEnd;

    private int score;

    private void Awake()
    {
      Application.targetFrameRate = 60;

      Play();
    }

    public void Play()
    {
       score = 0;
       scoreText.text = score.ToString();

       highscoreText.text = "highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

       playButton.SetActive(false);
       gameOver.SetActive(false);
       gameEnd.SetActive(false);

       Time.timeScale = 1f;
       player.enabled = true;

       Pipes[] pipes = FindObjectsOfType<Pipes>();

       for (int i = 0; i < pipes.Length; i++){
        Destroy(pipes[i].gameObject);
       }
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Pause()
    {
       Time.timeScale = 0f;
       player.enabled = false;
    }



    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        gameEnd.SetActive(true);

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
           PlayerPrefs.SetInt("HighScore", score);
           highscoreText.text = "highscore: " + score.ToString();
        }

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
