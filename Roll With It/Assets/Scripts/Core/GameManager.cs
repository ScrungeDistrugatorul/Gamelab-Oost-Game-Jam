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
    public int highscore;
    [SerializeField] private float timeLeftMultiplier;

    [Header("Timer")]
    public float timer;
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
        if (Input.GetKeyDown(KeyCode.Backspace))
            EndGame();

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

    public int GetFinalScore()
    {
        float timeScore = timeInSecs * timeLeftMultiplier;

        int finalScore = (int)timeScore + highscore;

        //Debug.Log(timeScore + "|" + highscore + "|" + finalScore);

        return finalScore;
    }
}
