using System.Collections;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public RectTransform notificationRect;
    public float slideDuration = 0.3f;
    public float displayTime = 2f;
    
    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;
    private TMPro.TextMeshProUGUI alertText;
    private bool isInitialized = false;
    
    void Start()
    {
        Initialize();
    }
    
    void Initialize()
    {
        if (isInitialized) return;
        
        if (notificationRect == null)
            notificationRect = GetComponent<RectTransform>();
        
        alertText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        
        if (alertText == null)
        {
            Debug.LogError("No TextMeshPro child found! Please add AlertText as child of NotificationPanel.");
            return;
        }
        
        hiddenPosition = new Vector2(notificationRect.anchoredPosition.x, 200);
        visiblePosition = new Vector2(notificationRect.anchoredPosition.x, -50);
        notificationRect.anchoredPosition = hiddenPosition;
        gameObject.SetActive(false);
        
        isInitialized = true;
        Debug.Log("Notification system initialized");
    }
    
    public void ShowNotification(string message)
    {
        if (!isInitialized)
            Initialize();
        
        if (alertText == null)
        {
            alertText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
            if (alertText == null)
            {
                Debug.LogError("Cannot show notification: AlertText not found!");
                return;
            }
        }
        
        StopAllCoroutines();
        gameObject.SetActive(true);
        alertText.text = message;
        StartCoroutine(AnimateNotification());
    }
    
    IEnumerator AnimateNotification()
    {
        float timer = 0;
        while (timer < slideDuration)
        {
            timer += Time.deltaTime;
            float t = timer / slideDuration;
            notificationRect.anchoredPosition = Vector2.Lerp(hiddenPosition, visiblePosition, t);
            yield return null;
        }
        
        yield return new WaitForSeconds(displayTime);
        
        timer = 0;
        while (timer < slideDuration)
        {
            timer += Time.deltaTime;
            float t = timer / slideDuration;
            notificationRect.anchoredPosition = Vector2.Lerp(visiblePosition, hiddenPosition, t);
            yield return null;
        }
        
        gameObject.SetActive(false);
    }
}