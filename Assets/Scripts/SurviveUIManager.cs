using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurviveUIManager : MonoBehaviour
{

    public Text scoreText; // 점수 표시용 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPracticeButton()
    {
        SceneManager.LoadScene("Practice");
        print("loadScene");
    }

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }

    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

}