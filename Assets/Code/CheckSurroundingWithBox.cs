using UnityEngine;

public class CheckSurroundingWithBox : MonoBehaviour
{
    public LayerMask objectLayer; // Hangi objeleri kontrol etmek istedi�imizi belirleyen katman

    public Vector3 boxCenter;
    public Vector3 boxSize = new Vector3(1f, 1f, 1f); // Kutunun boyutu

    public bool IsSpaceFree()
    {
        // Kutunun etraf�nda kalan colliderlar� alal�m
        Collider[] colliders = Physics.OverlapBox(transform.position + boxCenter, boxSize / 2, Quaternion.identity, objectLayer);

        // T�m collider'lar� kontrol et
        foreach (var collider in colliders)
        {
            // E�er herhangi bir "Cell_Empty" tag'ine sahip obje varsa alan bo�tur
            if (collider.CompareTag("Cell_Empty"))
            {
                return true; // Bo� h�cre bulundu, alan bo�
            }
        }

        // E�er bo� h�cre bulunmazsa t�m h�creler dolu kabul edilir
        return false; // T�m alan dolu
    }

    //Oyun sahnesinde etraf� g�rsel olarak �izmek i�in(iste�e ba�l�)
    [SerializeField] private bool showGizmos;

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + boxCenter, boxSize); // Kontrol edilecek kutunun boyutunu g�sterir
        }
    }
}