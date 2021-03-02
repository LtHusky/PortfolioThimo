using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // VARIABLES
    public static int score;
    public TMP_Text scoreText;
    
    // FUNCTIONS
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = "score: " + score.ToString();
    }
}