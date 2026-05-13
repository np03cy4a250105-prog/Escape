using UnityEngine;
using UnityEngine.UI;

public class Puzzle3_BigDrawer : MonoBehaviour
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
        
        GameManager.Instance.SolvePuzzle(3);
        Debug.Log("Puzzle 3 solved: Documents secured!");
    }
    
    public void OnLeaveClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(15f);
        Debug.Log("Wrong! Confidential documents exposed. -15 seconds.");
    }
    
    public void OnShredClick()
    {
        puzzlePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.Instance.AddTimePenalty(10f);
        Debug.Log("Shredding is good for old files, but current files need secure storage. -10 seconds.");
    }
}