using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour
{
    public Text scoreBoard;
    public int score;

    public delegate void Delegate(int num);
    public static Delegate callDelegate;

    private void Start()
    {
        callDelegate += AddScore;
    }

    public void AddScore(int addNum)
    {
        score += addNum;
        string scoreText = "Score: " + score.ToString();
        scoreBoard.text = scoreText;
    }
}
