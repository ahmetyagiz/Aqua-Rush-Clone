using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width, height;
    public GameObject[,] grid; // Her h�creyi bir GameObject (karakter veya duvar) ile temsil edelim

    void Start()
    {
        grid = new GameObject[width, height];
        // Burada grid'i doldur
    }

    public bool IsCellEmpty(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            return false; // Grid d���nda, yani kapal�
        }
        return grid[x, y] == null; // E�er h�cre bo�sa true, de�ilse false d�ner
    }
}