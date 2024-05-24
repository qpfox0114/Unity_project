using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int score;
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetBubble()
    {
        score += 10; // 碰到一次泡泡加十分
        DisplayScore();
    }

    public void BeAttacked()
    {
        score -= 10; // 遇到怪物扣分
        DisplayScore();
    }

    public void DisplayScore()
    {
        ScoreText.text = score.ToString();
    }
}
