using UnityEngine;

public class Character : MonoBehaviour
{
    public GridManager gridManager;
    public int posX, posY; // Karakterin grid �zerindeki pozisyonu
    public Color openColor; // E�er �evresi a��ksa bu renge de�i�
    public Color closedColor; // E�er �evresi kapal�ysa bu renge de�i�
    public Renderer characterRenderer;

    void Start()
    {
        UpdateCharacterColor();
    }

    void UpdateCharacterColor()
    {
        bool isSurrounded = true;

        // Sa�, Sol, �n, Arka ve �apraz y�nleri kontrol et
        if (gridManager.IsCellEmpty(posX + 1, posY)) isSurrounded = false; // Sa�
        if (gridManager.IsCellEmpty(posX - 1, posY)) isSurrounded = false; // Sol
        if (gridManager.IsCellEmpty(posX, posY + 1)) isSurrounded = false; // �n
        if (gridManager.IsCellEmpty(posX, posY - 1)) isSurrounded = false; // Arka
        if (gridManager.IsCellEmpty(posX + 1, posY + 1)) isSurrounded = false; // Sa�-�n �apraz
        if (gridManager.IsCellEmpty(posX - 1, posY + 1)) isSurrounded = false; // Sol-�n �apraz
        if (gridManager.IsCellEmpty(posX + 1, posY - 1)) isSurrounded = false; // Sa�-Arka �apraz
        if (gridManager.IsCellEmpty(posX - 1, posY - 1)) isSurrounded = false; // Sol-Arka �apraz

        // Rengi g�ncelle
        if (isSurrounded)
        {
            characterRenderer.material.color = closedColor;
        }
        else
        {
            characterRenderer.material.color = openColor;
        }
    }
}
