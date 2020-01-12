using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePassed : MonoBehaviour
{
    GameOverController gameOver;
    int seconds;
    Text timePassed;

    void Start()
    {
        gameOver = GameObject.Find("Game Over").GetComponent<GameOverController>();
        timePassed = transform.GetComponent<Text>();
    }

    void Update()
    {
        seconds = gameOver.seconds;
        timePassed.text = seconds.ToString();
    }
}
