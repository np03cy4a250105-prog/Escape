using UnityEngine;
using UnityEngine.UI;

public class Puzzle2_ServerRack : MonoBehaviour
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
    
    public void OnLockClick()
    {
        puzzlePanel.SetActive(false);
        isSolved = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.SolvePuzzle(2);
        Debug.Log("Puzzle 2 solved: Server rack locked!");
    }
    
    public void OnLeaveClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(15f);
        Debug.Log("Wrong! Unlocked rack = physical data access. -15 seconds.");
    }
    
    public void OnShutdownClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(30f);
        Debug.Log("Wrong! Never shut down active servers without protocol. -30 seconds.");
    }
}