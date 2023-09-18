using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemySpawner;
    public GameObject[] EnemyHitPoints;
    public SurviveUIManager uiManager;
    public AudioSource audioSource;
    public AudioClip deadBell;

    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;

    private int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            uiManager.UpdateScoreText(score);
        }
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(deadBell);

        int bestScore = PlayerPrefs.GetInt("UserBestScore", 0);
        uiManager.UpdateBestScoreText(bestScore);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("UserBestScore", score);
            PlayerPrefs.Save();
        }

        EnemySpawner.SetActive(false);
        foreach (GameObject point in EnemyHitPoints)
        {
            point.SetActive(false);
        }
        uiManager.SetActiveGameoverUI(true);
    }
}
