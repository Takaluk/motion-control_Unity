using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurviveUIManager : MonoBehaviour
{

    public Text scoreText; 
    public Text BestScoreText;
    public GameObject gameoverUI; 

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

    public void UpdateBestScoreText(int BestScore)
    {
        BestScoreText.text = "Best Score : " + BestScore;
    }

    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

}