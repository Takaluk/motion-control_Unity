using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemySpawner;
    public SurviveUIManager uiManager;
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    private int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; } // 게임 오버 상태

    public void AddScore(int newScore)
    {
        // 게임 오버가 아닌 상태에서만 점수 증가 가능
        if (!isGameover)
        {
            // 점수 추가
            score += newScore;
            // 점수 UI 텍스트 갱신
            uiManager.UpdateScoreText(score);
        }
    }

    public void GameOver()
    {
        EnemySpawner.SetActive(false);
        uiManager.SetActiveGameoverUI(true);
    }
}
