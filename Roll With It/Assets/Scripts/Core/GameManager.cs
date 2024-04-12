using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameManager")]
    public static GameManager instance;

    [Header("Highscore")]
    [SerializeField] private int highscore;
    [SerializeField] private float timeLeftMultiplier;

    [Header("Timer")]
    [SerializeField] private float timer;
    [SerializeField] private float timeInSecs;
    [SerializeField] private float maxTimeInMin;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        timeInSecs = maxTimeInMin * 60;
    }

    void Update()
    {
        Timer();
        GameRun();
    }

    private void GameRun()
    {
        if(timer == 0 || true)
        {
            EndGame();
        }
    }

    private void Timer()
    {
        timeInSecs -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(timeInSecs / 60);
        float seconds = Mathf.FloorToInt(timeInSecs % 60);
        seconds /= 100;

        timer = minutes + seconds;

        if(timer <= 0)
        {
            timer = 0;
        }
    }

    public static void EndGame()
    {
        // Game Over - End Screen

        float timeHighScore = instance.timeInSecs * instance.timeLeftMultiplier;
        AddHighscore((int)timeHighScore);


        // Next Scene;
    }

    public static float GetTime()
    {
        return instance.timer;
    }

    public static void AddHighscore(int highscore)
    {
        instance.highscore += highscore;
    }
}
