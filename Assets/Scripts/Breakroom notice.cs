using UnityEngine;

public class BreakRoomNotice : MonoBehaviour
{
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            GameManager.Instance.ShowNotification("Break room: RELAX. No vulnerabilities to fix.");
        }
    }
}