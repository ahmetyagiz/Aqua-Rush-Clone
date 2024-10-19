using UnityEngine;

public class CheckSurroundingWithBox : MonoBehaviour
{
    public LayerMask objectLayer; // Hangi objeleri kontrol etmek istedi�imizi belirleyen katman
    public Vector3 boxSize = new Vector3(1f, 1f, 1f); // Kutunun boyutu

    public bool IsSpaceFree()
    {
        // Karakterin pozisyonuna g�re merkez al�p etraf�nda bir kutu olu�tural�m
        Vector3 boxCenter = transform.position;

        // Kutunun etraf�nda kalan colliderlar� alal�m
        Collider[] colliders = Physics.OverlapBox(boxCenter, boxSize / 2, Quaternion.identity, objectLayer);

        // T�m collider'lar� kontrol et
        foreach (var collider in colliders)
        {
            // E�er herhangi bir "Empty_Cell" tag'ine sahip obje varsa alan bo�tur
            if (collider.CompareTag("Empty_Cell"))
            {
                return true; // Bo� h�cre bulundu, alan bo�
            }
        }

        // E�er bo� h�cre bulunmazsa t�m h�creler dolu kabul edilir
        return false; // T�m alan dolu
    }

    // Oyun sahnesinde etraf� g�rsel olarak �izmek i�in (iste�e ba�l�)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize); // Kontrol edilecek kutunun boyutunu g�sterir
    }
}