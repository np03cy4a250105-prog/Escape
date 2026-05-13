using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    private int pressCount = 0;

    void OnMouseDown()
    {
        pressCount++;
        
        if (pressCount == 1)
        {
            Debug.Log("VENDING MACHINE: *beep* Button pressed.");
            GameManager.Instance.ShowNotification("*beep* Button pressed.");
        }
        else if (pressCount == 2)
        {
            Debug.Log("VENDING MACHINE: Screen flickers... No network connection detected.");
            GameManager.Instance.ShowNotification("Screen flickers... No network connection.");
        }
        else if (pressCount == 3)
        {
            Debug.Log("VENDING MACHINE: Machine is offline. No data breach risk.");
            GameManager.Instance.ShowNotification("Machine offline. No data breach risk.");
        }
        else
        {
            Debug.Log("VENDING MACHINE: *clunk* A snack drops. Machine isolated from company network.");
            GameManager.Instance.ShowNotification("*clunk* Snack drops. Machine is isolated.");
        }
    }
}