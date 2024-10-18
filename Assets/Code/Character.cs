using UnityEngine;

public class Character : MonoBehaviour
{
    public GridManager gridManager;
    public int posX, posY; // Karakterin grid üzerindeki pozisyonu
    public Color openColor; // Eðer çevresi açýksa bu renge deðiþ
    public Color closedColor; // Eðer çevresi kapalýysa bu renge deðiþ
    public Renderer characterRenderer;

    void Start()
    {
        UpdateCharacterColor();
    }

    void UpdateCharacterColor()
    {
        bool isSurrounded = true;

        // Sað, Sol, Ön, Arka ve Çapraz yönleri kontrol et
        if (gridManager.IsCellEmpty(posX + 1, posY)) isSurrounded = false; // Sað
        if (gridManager.IsCellEmpty(posX - 1, posY)) isSurrounded = false; // Sol
        if (gridManager.IsCellEmpty(posX, posY + 1)) isSurrounded = false; // Ön
        if (gridManager.IsCellEmpty(posX, posY - 1)) isSurrounded = false; // Arka
        if (gridManager.IsCellEmpty(posX + 1, posY + 1)) isSurrounded = false; // Sað-Ön çapraz
        if (gridManager.IsCellEmpty(posX - 1, posY + 1)) isSurrounded = false; // Sol-Ön çapraz
        if (gridManager.IsCellEmpty(posX + 1, posY - 1)) isSurrounded = false; // Sað-Arka çapraz
        if (gridManager.IsCellEmpty(posX - 1, posY - 1)) isSurrounded = false; // Sol-Arka çapraz

        // Rengi güncelle
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
