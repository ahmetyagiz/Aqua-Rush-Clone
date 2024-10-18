using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 10; // Toplam satýr sayýsý
    public int columns = 10; // Toplam sütun sayýsý
    public float cellSize = 1f; // Hücre boyutu

    // Grid'in merkezini hesaplamak için
    private Vector3 GetGridCenter()
    {
        float xCenter = (columns * cellSize) / 2f;
        float yCenter = (rows * cellSize) / 2f;
        return new Vector3(xCenter, 0, yCenter);
    }

    // Grid'deki pozisyonu dünya pozisyonuna çevirir (Pivotu merkeze alýr)
    public Vector3 GetWorldPosition(int x, int y)
    {
        Vector3 gridCenter = GetGridCenter();
        return new Vector3(x * cellSize, 0, y * cellSize) - gridCenter;
    }

    // Dünyadaki pozisyonu grid pozisyonuna çevirir
    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        Vector3 gridCenter = GetGridCenter();
        Vector3 adjustedPosition = worldPosition + gridCenter;
        int x = Mathf.FloorToInt(adjustedPosition.x / cellSize);
        int y = Mathf.FloorToInt(adjustedPosition.z / cellSize);
        return new Vector2Int(x, y);
    }
}