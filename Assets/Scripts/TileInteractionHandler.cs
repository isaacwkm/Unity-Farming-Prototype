using UnityEngine;

public class TileInteractionHandler : MonoBehaviour
{
    private Renderer tileRenderer;
    private Color originalColor;

    public Color highlightColor = Color.yellow;

    private void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        tileRenderer.material.color = highlightColor;
    }

    private void OnMouseExit()
    {
        tileRenderer.material.color = originalColor;
    }

    private void OnMouseDown()
    {
        //TileManager.Instance.ShowPlantMenu(this);
    }
}