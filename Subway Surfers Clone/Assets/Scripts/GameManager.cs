using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float time;
    private int maxSpeed = 50;

    public float obstacleSpawnDelay;
    public float speedIncreasment;
    public float gameSpeed;
    public int highScore;
    public int score;
    public bool canPlay;

    public static GameManager Instance {get; private set;}


    private void Awake()
    {
        if (Instance != null && Instance == this)
        {
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.startScreen.SetActive(true);
        UIManager.Instance.gameOverScreen.SetActive(false);
        canPlay = false;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        if (!canPlay){return;}

        if (Time.time - time > 0.5)
        {
            score++;
            time = Time.time;
        }
        if (score % 10 == 0 && gameSpeed < maxSpeed)
        {
            gameSpeed += speedIncreasment;
            score++;
        }
    }

    public void StartGame()
    {
        canPlay = true;
        score = 0;
        time = Time.time;
        UIManager.Instance.startScreen.SetActive(false);
        AnimationController.Instance.RunAnimation(true);
    }

    public void FinishGame()
    {
        UIManager.Instance.gameOverScreen.SetActive(true);
        canPlay = false;
        if (score > highScore)
        {
            highScore = score;
        }
        PlayerPrefs.SetInt("HighScore",highScore);
        UIManager.Instance.DisplayScores();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        StartGame();
    }
}
