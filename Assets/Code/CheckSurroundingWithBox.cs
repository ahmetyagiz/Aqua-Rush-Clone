using UnityEngine;

public class CheckSurroundingWithBox : MonoBehaviour
{
    public LayerMask objectLayer; // Hangi objeleri kontrol etmek istediðimizi belirleyen katman
    public Vector3 boxSize = new Vector3(1f, 1f, 1f); // Kutunun boyutu

    public bool IsSpaceFree()
    {
        // Karakterin pozisyonuna göre merkez alýp etrafýnda bir kutu oluþturalým
        Vector3 boxCenter = transform.position;

        // Kutunun etrafýnda kalan colliderlarý alalým
        Collider[] colliders = Physics.OverlapBox(boxCenter, boxSize / 2, Quaternion.identity, objectLayer);

        // Tüm collider'larý kontrol et
        foreach (var collider in colliders)
        {
            // Eðer herhangi bir "Empty_Cell" tag'ine sahip obje varsa alan boþtur
            if (collider.CompareTag("Empty_Cell"))
            {
                return true; // Boþ hücre bulundu, alan boþ
            }
        }

        // Eðer boþ hücre bulunmazsa tüm hücreler dolu kabul edilir
        return false; // Tüm alan dolu
    }

    // Oyun sahnesinde etrafý görsel olarak çizmek için (isteðe baðlý)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize); // Kontrol edilecek kutunun boyutunu gösterir
    }
}