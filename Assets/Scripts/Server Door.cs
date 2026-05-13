using UnityEngine;

public class ServerDoor : MonoBehaviour
{
    private bool hasNotified = false;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.puzzlesSolved >= 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasNotified)
        {
            hasNotified = true;
            GameManager.Instance.ShowNotification("Server room locked! Complete 2 puzzles to unlock.");
        }
    }
}