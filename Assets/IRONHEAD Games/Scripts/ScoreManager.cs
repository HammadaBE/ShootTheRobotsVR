using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score = 0;
    public TMP_Text scoreText; // Reference to the Text component in the UI

    public TMP_Text timerText;
    public TMP_Text winLoseText;
    public int winThreshold = 10;
    private float timeLeft = 60.0f; // Two minutes
    private bool timerEnded = false;



    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Multiple instances of ScoreManager detected. Destroying this instance.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>(); // Replace "Text" with "TMP_Text" if using TextMeshPro
        scoreText.text = "Destory the robots \n Cube : 1 pt \nSphere 2pt \n Score: " + score + "\n Get 10 pt to win";

        timerText = GameObject.Find("Timer Text").GetComponent<TMP_Text>();
        winLoseText = GameObject.Find("WinLoseText").GetComponent<TMP_Text>();
        winLoseText.enabled = false; // Make sure it's initially hidden

    }


    private void Start()
    {
        // Find the Text component if not assigned in the Inspector
        if (scoreText == null)
            scoreText = GetComponentInChildren<TMP_Text>();

        UpdateScoreUI(); // Update the initial score in the UI
    }

    public void UpdateScore(int points)
    {
        Debug.Log($"Updating score {score} with {points} points");
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Destory the robots \n Cube : 1 pt \nSphere 2pt \n Score: " + score + "\n Get 10 pt to win";
    }

    void Update()
    {
        if (!timerEnded)
        {
            // Update the timer
            timeLeft -= Time.deltaTime;
            timerText.text = $"Time left: {Mathf.Max(0, timeLeft):0}";

            // Check if the timer has reached zero
            if (timeLeft <= 0)
            {
                timerEnded = true;
                timerText.enabled = false;
                CheckWinLoseCondition();
            }
        }
    }

    private void CheckWinLoseCondition()
    {
        Debug.Log($"Checking win/lose condition with score: {score}");

        if (score >= winThreshold)
        {
            winLoseText.text = "You Win!";
        }
        else
        {
            winLoseText.text = "You Lose!";
        }

        winLoseText.enabled = true;
    }


}
