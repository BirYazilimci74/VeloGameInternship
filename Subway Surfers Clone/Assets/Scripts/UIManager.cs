using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text inGameScoreText;
    public GameObject gameOverScreen;

    public static UIManager Instance {get; private set;}

    
    private void Awake()
    {
        if (Instance != null && Instance == this)
        {
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance.score > GameManager.Instance.highScore)
        {
            inGameScoreText.color = Color.green;
        }
        inGameScoreText.text = "Score: " + GameManager.Instance.score.ToString();
    }

    public void DisplayScores()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        highScoreText.text = GameManager.Instance.highScore.ToString();
    }
}
