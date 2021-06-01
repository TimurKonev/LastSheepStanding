using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public bool buttonClicked = false;
    public GameObject ui;

    void Start()
    {
        Pause();
    }

    void Update()
    {
        if (buttonClicked)
        {
            if (GameIsPaused)
            {
                Resume();
                buttonClicked = false;
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        ui.SetActive(false);
    }

    public void OnClick()
    {
        buttonClicked = true;
    }
    
}
