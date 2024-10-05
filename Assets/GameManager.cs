using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    [Header("Game Settings")]
    public float scoreInterval = 1f;

    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
        gameOverText.gameObject.SetActive(false);
        InvokeRepeating("IncrementScore", scoreInterval, scoreInterval);
    }

    public void IncrementScore()
    {
        if (!isGameOver)
        {
            score++;
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        CancelInvoke("IncrementScore");
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
