using UnityEngine;

public class TileInteractionHandler : MonoBehaviour
{
    private Renderer tileRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow;
    private GridManager gridManager;

    private void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;
        gridManager = FindObjectOfType<GridManager>();
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
        Tile tile = gridManager.GetTileAt(tileRenderer.transform.position);
        SowPlant.Instance.ShowPlantMenu(tile);
    }
}