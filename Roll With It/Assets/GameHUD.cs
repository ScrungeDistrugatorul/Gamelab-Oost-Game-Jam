using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text time;

    private GameManager gm;
    
    private void Start()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        if (gm is null) return;
        time.text = "Time left: "+ gm.timer.ToString();
    }
}
