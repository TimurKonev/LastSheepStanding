using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject youWinUI;
    [SerializeField] private GameObject player;
    [SerializeField]private GameObject sheep;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
            
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.collider.gameObject);
                GameOver();
            }
            else if (collision.gameObject.CompareTag("Sheep"))
            {
                Destroy(collision.collider.gameObject);
                Enemy.count--;
                if (Enemy.count == 0)
                {
                    YouWin();
                }
            }
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void YouWin()
    {
            youWinUI.SetActive(true);
            Time.timeScale = 0f;
    }
}
