using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public static TimeCounter instance;

    public float startGameTime = 0f;
    public float currentGameTime = 0f;
    public TimeSpan timePlaying;
    public Text timerText;

    TimeSpan duration = new TimeSpan(1, 12, 23, 1);

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGameTime = startGameTime;

    }

    // Update is called once per frame
    void Update()
    {
        CountTimer();
    }

    public void CountTimer()
    {

        if (currentGameTime > 0f)
        {
            currentGameTime -= 1f * Time.deltaTime;

            timePlaying = TimeSpan.FromSeconds(currentGameTime);

            string playString = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = playString;
        }
        else
        {
            GameManager.instance.EndGame(false);
        }
    }

    public void RestartTimer()
    {
        currentGameTime = startGameTime;
    }
}
