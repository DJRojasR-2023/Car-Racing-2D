using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controle : MonoBehaviour
{
    public Text highScoreText;
    public Text scoreText;

    public int score;
    public int highScore;

    public score_manager score_Manager;
    public GameObject gamePausePanel;

    private bool isGamePaused = false;

    void Start()
    {
        // Inicializa aquí tus variables u objetos si es necesario.
        gamePausePanel.SetActive(false);
    }

    void Update()
    {
        if (!isGamePaused)
        {
            // Realiza acciones en el juego dentro de este método.
            highScore = PlayerPrefs.GetInt("high_score");
            score = score_Manager.score;

            highScoreText.text = "Highscore: " + highScore.ToString();
            scoreText.text = "Your Score: " + score.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        isGamePaused = false;
    }
}