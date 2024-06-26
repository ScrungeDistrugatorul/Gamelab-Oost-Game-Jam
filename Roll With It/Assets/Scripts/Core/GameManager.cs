using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int TimeLeft => (int)timeInSecs;
    public int Highscore => highscore;

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
        if (SceneManager.GetActiveScene().name != "MainScene") return;
        Timer();
        GameRun();
    }

    private void GameRun()
    {
        if(timer == 0)
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

        // float timeHighScore = instance.timeInSecs * instance.timeLeftMultiplier;
        // AddHighscore((int)timeHighScore);


        // Next Scene;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("EndScene");
    }

    public static float GetTime()
    {
        return instance.timer;
    }

    public static void AddHighscore(int highscore)
    {
        instance.highscore += highscore;
    }

    public int GetTimeScore()
    {
        return (int)(instance.timeInSecs * instance.timeLeftMultiplier);
    }
}
