using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width, height;
    public GameObject[,] grid; // Her hücreyi bir GameObject (karakter veya duvar) ile temsil edelim

    void Start()
    {
        grid = new GameObject[width, height];
        // Burada grid'i doldur
    }

    public bool IsCellEmpty(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            return false; // Grid dýþýnda, yani kapalý
        }
        return grid[x, y] == null; // Eðer hücre boþsa true, deðilse false döner
    }
}