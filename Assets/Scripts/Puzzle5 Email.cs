using UnityEngine;
using UnityEngine.UI;

public class Puzzle5_Email : MonoBehaviour
{
    public GameObject puzzlePanel;
    private bool isSolved = false;
    
    void Start()
    {
        if (puzzlePanel != null)
            puzzlePanel.SetActive(false);
    }
    
    void OnMouseDown()
    {
        if (!isSolved)
        {
            puzzlePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
    public void OnReportClick()
    {
        puzzlePanel.SetActive(false);
        isSolved = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.SolvePuzzle(5);
        Debug.Log("Puzzle 5 solved: Phishing email reported!");
    }
    
    public void OnClickClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(30f);
        Debug.Log("Wrong! You clicked a malicious link. -30 seconds.");
    }
    
    public void OnDeleteClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(10f);
        Debug.Log("Deleting is okay, but reporting helps protect others. -10 seconds.");
    }
}