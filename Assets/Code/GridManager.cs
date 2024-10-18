using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 10; // Toplam sat�r say�s�
    public int columns = 10; // Toplam s�tun say�s�
    public float cellSize = 1f; // H�cre boyutu

    // Grid'in merkezini hesaplamak i�in
    private Vector3 GetGridCenter()
    {
        float xCenter = (columns * cellSize) / 2f;
        float yCenter = (rows * cellSize) / 2f;
        return new Vector3(xCenter, 0, yCenter);
    }

    // Grid'deki pozisyonu d�nya pozisyonuna �evirir (Pivotu merkeze al�r)
    public Vector3 GetWorldPosition(int x, int y)
    {
        Vector3 gridCenter = GetGridCenter();
        return new Vector3(x * cellSize, 0, y * cellSize) - gridCenter;
    }

    // D�nyadaki pozisyonu grid pozisyonuna �evirir
    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        Vector3 gridCenter = GetGridCenter();
        Vector3 adjustedPosition = worldPosition + gridCenter;
        int x = Mathf.FloorToInt(adjustedPosition.x / cellSize);
        int y = Mathf.FloorToInt(adjustedPosition.z / cellSize);
        return new Vector2Int(x, y);
    }
}