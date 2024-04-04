using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highestScoreText; 
    private float score;
    private float highestScore; 
    void Start()
    {
        highestScore = PlayerPrefs.GetFloat("HighestScore", 0f);
        highestScoreText.text = "Highest Score: " + highestScore.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();

            if (score > highestScore)
            {
                highestScore = score;
                highestScoreText.text = "Highest Score: " + highestScore.ToString("F0");

                PlayerPrefs.SetFloat("HighestScore", highestScore);
                PlayerPrefs.Save(); 
            }
        }
    }
}


