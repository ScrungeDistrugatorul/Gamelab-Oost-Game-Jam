using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetFloat("sens", 0.5f);
    }

    public void PlayGame()
    {
        Debug.Log("Scene Change");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(0);
    }

    public void AddSense(float sens)
    {
        PlayerPrefs.SetFloat("sens", sens);
        PlayerPrefs.Save();
    }
}
