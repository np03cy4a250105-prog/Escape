using UnityEngine;
using UnityEngine.UI;

public class Puzzle4_Printer : MonoBehaviour
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
    
    public void OnClearClick()
    {
        puzzlePanel.SetActive(false);
        isSolved = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.SolvePuzzle(4);
        Debug.Log("Puzzle 4 solved: Print queue cleared!");
    }
    
    public void OnLeaveClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(15f);
        Debug.Log("Wrong! Sensitive documents left in printer. -15 seconds.");
    }
    
    public void OnOffClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(5f);
        Debug.Log("Turning off printer doesn't clear the queue. -5 seconds.");
    }
}