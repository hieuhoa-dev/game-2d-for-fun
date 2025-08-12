using UnityEngine;
using TMPro; // Manage UI text
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject gameWinUi;
    private bool isGameOver = false;
    private bool isGameWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
        gameOverUi.SetActive(false);
        gameWinUi.SetActive(false);
    }


    public void AddScore(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points;
            UpdateScore();

        }
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0; // Don't let players click
        gameOverUi.SetActive(true);
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0; // Don't let players click
        gameWinUi.SetActive(true);
    }

    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    
    public bool IsGameWin()
    {
        return isGameWin;
    }

}
