using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);

        if (gameOver.activeSelf)
        {
            gameOver.SetActive(false);
        }
        else
        {
            getReady.SetActive(false);
        }       

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
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

        Pause();
    }
    public void IncreaseScore()
    {
        score ++;
        scoreText.text = score.ToString();
    }
}