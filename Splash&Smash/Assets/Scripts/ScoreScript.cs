using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public int score;
    public TMP_Text txtScore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int points)
    {
        score += points;
        txtScore.text = score.ToString();
    }



}
