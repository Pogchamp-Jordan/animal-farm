using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text endScreenScoreText;
    public Text highScoreText;

    private float score;
    private float highScore = 0;
    private bool isRunning;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Score Manager Instance Already Created");
        }

        StopGame();
        HideText();
    }


    public void StartGame()
    {
        score = 0;
        isRunning = true;
        scoreText.gameObject.SetActive(true);
        HideEndScreenText();
        StartCoroutine(IncrementScore());
    }

    private IEnumerator IncrementScore()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            scoreText.text = "Score: " + score;
        }
        
    }

    public void StopGame()
    {
        isRunning = false;
        if (score > highScore)
        {
            highScore = score;
        }
        
    }

    public void HideText()
    {
        scoreText.gameObject.SetActive(false);
    }

    public void ShowEndScreenText()
    {
        endScreenScoreText.text = "Score: " + score;
        endScreenScoreText.gameObject.SetActive(true);

        highScoreText.text = "High Score: " + highScore;
        highScoreText.gameObject.SetActive(false);
    }

    public void HideEndScreenText()
    {
        endScreenScoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }
}
