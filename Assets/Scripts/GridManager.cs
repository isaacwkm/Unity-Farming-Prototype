using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int Rows = 3;
    public int Columns = 3;
    readonly float TileSize = 2f;
    public Tile[,] Grid;

    private void Start()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        Grid = new Tile[Rows, Columns];
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                Vector2 position = new(i * TileSize, j * TileSize);
                Grid[i, j] = new Tile(position);
            }
        }
    }

    public Tile GetTileAt(Vector3 position)
    {
        int i = Mathf.FloorToInt(GetCoordinate(position.x));
        int j = Mathf.FloorToInt(GetCoordinate(position.z));

        if (i >= 0 && i <= Columns && j >= 0 && j <= Rows)
        {
            return Grid[i, j];
        }
        return null;
    }

    public float GetCoordinate(float coordinate) {
        return coordinate / TileSize;
    }
    public float GetSize() {
        return TileSize;
    }
}

public class Tile
{
    public Vector2 Position;
    public Tile(Vector2 position)
    {
        Position = position;
    }
}