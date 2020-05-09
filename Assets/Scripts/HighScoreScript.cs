using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public static HighScoreScript inctance; 

    public Text score, highScore;
    public int scoreCounter, highScoreCounter;

    private void Awake()
    {
        inctance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
        { 
            highScoreCounter = PlayerPrefs.GetInt("SaveScore");
        }
    }

    void Update()
    {
        score.text = $"Score: {scoreCounter}";
        highScore.text = $"HighScore: {highScoreCounter}";

        if (Input.GetKeyDown(KeyCode.Space))
        {
           inctance.AddScore();
        }
         

    }

    public void AddScore()
    {
        scoreCounter++;
        HighScore();
    }
    public void HighScore()
    {
        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
        }

        PlayerPrefs.SetInt("SaveScore", highScoreCounter);
    }

    public void ResetScore() => scoreCounter = 0;

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScore");
        highScoreCounter = 0;
    }

}
