using Unity.VisualScripting;
using UnityEngine;

public class SowPlant : MonoBehaviour
{
    public static SowPlant Instance;

    public GameObject plantMenuUI; // Reference to the plant selection UI
    private Tile selectedTile;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowPlantMenu(Tile tile)
    {
        selectedTile = tile;
        plantMenuUI.SetActive(true);
        // Optionally, position the menu near the tile - potential feature when I have time - Isaac
    }

    public void PlantSelected(GameObject plantPrefab)
    {
        //Vector3 selectedTileCoords = [];
        if (selectedTile != null)
        {
            Instantiate(plantPrefab, selectedTile.Position, Quaternion.identity);
            plantMenuUI.SetActive(false);
            selectedTile = null;
        }
    }
}
