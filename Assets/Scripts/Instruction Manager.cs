using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject playerController;
    public GameObject timerText;
    public GameObject crosshair;
    public GameObject alertText;
    
    void Start()
    {
        Time.timeScale = 0f;
        instructionsPanel.SetActive(true);
        
        if (playerController != null)
        {
            playerController.GetComponent<CharacterController>().enabled = false;
            playerController.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        }
        if (timerText != null) timerText.SetActive(false);
        if (crosshair != null) crosshair.SetActive(false);
        if (alertText != null) alertText.SetActive(false);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void StartGame()
    {
        instructionsPanel.SetActive(false);
        Time.timeScale = 1f;
        
        if (playerController != null)
        {
            playerController.GetComponent<CharacterController>().enabled = true;
            playerController.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
        }
        if (timerText != null) timerText.SetActive(true);
        if (crosshair != null) crosshair.SetActive(true);
        if (alertText != null) alertText.SetActive(true);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}