using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class endScore : MonoBehaviour
{
    public TextMeshProUGUI sc;
    // public score sco;

    // Start is called before the first frame update
    public void Start()
    {
        sc = GetComponent<TextMeshProUGUI>();
        //s = FindObjectOfType<score>().getHighScore();
        if (player.hole == "")
        {
            sc.text = "Score: " + score.scoreValue.ToString() + "\nHighest: " + score.highScore.ToString();
        }
        else
        {
            sc.text = player.hole;
        }
    }
}
