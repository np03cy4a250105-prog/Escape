using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int puzzlesSolved = 0;
    public int totalPuzzles = 5;
    public float timeRemaining = 600f;
    public TMPro.TextMeshProUGUI timerText;
    public Notification notification;
    public GameObject victoryPanel;
    public GameObject gameOverPanel;
    
    public GameObject summaryPanel;
    public TMPro.TextMeshProUGUI summaryTimeText;
    public TMPro.TextMeshProUGUI summaryScoreText;
    public TMPro.TextMeshProUGUI summaryFeedbackText;
    private float gameStartTime;
    
    private bool gameActive = true;
    
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        summaryPanel.SetActive(false);
        gameStartTime = Time.time;
        
        // Pre-warm notification system
        if (notification != null)
        {
            notification.gameObject.SetActive(true);
            notification.gameObject.SetActive(false);
            Debug.Log("Notification system initialized");
        }
    }
    
    void Update()
    {
        if (!gameActive) return;
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            GameOver();
        }
    }
    
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    
    public void ShowNotification(string message)
    {
        if (notification != null)
        {
            notification.ShowNotification(message);
            Debug.Log("Notification shown: " + message);
        }
        else
        {
            Debug.LogError("Notification component missing! Assign NotificationPanel to GameManager.");
        }
    }
    
    public void SolvePuzzle(int puzzleID)  
    {
        puzzlesSolved++;
        
        string message = "";
        switch (puzzleID)
        {
            case 1:
                message = "Workstation secured: Unauthorized access blocked";
                break;
            case 2:
                message = "Server rack secured: Physical access restricted";
                break;
            case 3:
                message = "Documents secured: Data leakage prevented";
                break;
            case 4:
                message = "Print security enforced: Print queue cleared";
                break;
            case 5:
                message = "Phishing email reported: Suspicious email neutralized";
                break;
        }
        
        Debug.Log("Puzzle " + puzzleID + " solved! Message: " + message);
        ShowNotification(message);
        
        if (puzzlesSolved >= totalPuzzles)
        {
            Victory();
        }
    }
    
    public void AddTimePenalty(float seconds)
    {
        timeRemaining -= seconds;
        ShowNotification("Time penalty: -" + seconds + " seconds");
        Debug.Log("Time penalty: -" + seconds + " seconds");
        
        if (timeRemaining <= 0)
        {
            GameOver();
        }
    }
    
    void Victory()
    {
        gameActive = false;
        ShowSummary();
    }
    
    void ShowSummary()
    {
        float timeTaken = Time.time - gameStartTime;
        int minutes = Mathf.FloorToInt(timeTaken / 60);
        int seconds = Mathf.FloorToInt(timeTaken % 60);
        
        summaryTimeText.text = string.Format("Time taken: {0:00}:{1:00}", minutes, seconds);
        summaryScoreText.text = "Puzzles solved: " + puzzlesSolved + "/" + totalPuzzles;
        
        if (puzzlesSolved >= totalPuzzles)
        {
            if (timeTaken < 180)
                summaryFeedbackText.text = "Excellent! You demonstrated strong security awareness!";
            else if (timeTaken < 300)
                summaryFeedbackText.text = "Good work! You identified all security risks.";
            else
                summaryFeedbackText.text = "You completed the training. Try to be faster next time.";
        }
        else
        {
            summaryFeedbackText.text = "You missed some vulnerabilities. Review the training and try again.";
        }
        
        summaryPanel.SetActive(true);
        victoryPanel.SetActive(false);
    }
    
    public void RestartGame()
    {
        puzzlesSolved = 0;
        timeRemaining = 600f;
        gameActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void CloseGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
    void GameOver()
    {
        gameActive = false;
        gameOverPanel.SetActive(true);
    }
}