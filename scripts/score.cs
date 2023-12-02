using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int highScore = 0;
    public TextMeshProUGUI sc;

    // Start is called before the first frame update
    public void Start()
    {
        sc = GetComponent<TextMeshProUGUI>();
        sc.text = scoreValue.ToString();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        //DontDestroyOnLoad(this);
    }

    public int getScore()
    {
        return scoreValue;
    }

    public int getHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        return 2;
    }

    public void begin()
    {
        scoreValue = 0;
        sc.text = "Tap to begin";
    }

    public void show()
    {
        sc.text = scoreValue.ToString() + "\nHS: " + highScore.ToString();
    }

    // Update is called once per frame
    public void addPoint()
    {
        scoreValue++;
        if (scoreValue > highScore) //if the score is bigger than the highscore
        {
            PlayerPrefs.SetInt("highScore", scoreValue);
        }
        sc.text = scoreValue.ToString() + "\nHS: " + highScore.ToString();
    }
}
