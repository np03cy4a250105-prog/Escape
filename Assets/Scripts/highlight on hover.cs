using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Material originalMaterial;
    private Renderer objectRenderer;
    public Material highlightMaterial;
    
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }
    
    void OnMouseEnter()
    {
        objectRenderer.material = highlightMaterial;
    }
    
    void OnMouseExit()
    {
        objectRenderer.material = originalMaterial;
    }
}