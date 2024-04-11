using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Highscore")]
    [SerializeField] private int highscore;

    [Header("Timer")]
    [SerializeField] private float timer;
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTimeInMin;


    void Start()
    {
        currentTime = maxTimeInMin * 60;
    }


    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        currentTime -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        seconds /= 100;

        timer = minutes + seconds;
    }
}

public enum GameState
{
    
}
