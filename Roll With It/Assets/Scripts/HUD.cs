using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TrashCan trashCan;
    public TMP_Text total, highscore, timer;

    private void Update()
    {
        total.text = $"{trashCan.TrashAmount} / {trashCan.TotalTrash}";
        highscore.text = $"Highscore: {GameManager.GetHighscore()}";
        timer.text = $"Time: {GameManager.GetTime()}";
    }
}
