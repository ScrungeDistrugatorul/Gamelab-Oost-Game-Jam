using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text score, time, final;

    private void Start()
    {
        GameManager gm = GameManager.instance;
        if (gm == null) return;
        score.text = gm.Highscore.ToString();
        time.text = gm.TimeLeft.ToString();
        final.text = gm.GetFinalScore().ToString();
    }
}
