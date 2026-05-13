using UnityEngine;
using UnityEngine.UI;

public class Puzzle1_Workstation : MonoBehaviour
{
    public GameObject puzzlePanel;
    private bool isSolved = false;
    
    void Start()
    {
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
    
    public void OnLockClick()
    {
        puzzlePanel.SetActive(false);
        isSolved = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.SolvePuzzle(1);
        Debug.Log("Puzzle 1 solved: Workstation locked!");
    }
    
    public void OnLeaveClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(15f);
        Debug.Log("Wrong! Unlocked screens expose sensitive data. -15 seconds.");
    }
    
    public void OnShutdownClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(5f);
        Debug.Log("Shutting down is good, but locking is faster for security. -5 seconds.");
    }
}