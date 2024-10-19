using UnityEngine;

public class CheckSurroundingWithBox : MonoBehaviour
{
    public LayerMask objectLayer; // Hangi objeleri kontrol etmek istediðimizi belirleyen katman

    public Vector3 boxCenter;
    public Vector3 boxSize = new Vector3(1f, 1f, 1f); // Kutunun boyutu

    public bool IsSpaceFree()
    {
        // Kutunun etrafýnda kalan colliderlarý alalým
        Collider[] colliders = Physics.OverlapBox(transform.position + boxCenter, boxSize / 2, Quaternion.identity, objectLayer);

        // Tüm collider'larý kontrol et
        foreach (var collider in colliders)
        {
            // Eðer herhangi bir "Cell_Empty" tag'ine sahip obje varsa alan boþtur
            if (collider.CompareTag("Cell_Empty"))
            {
                return true; // Boþ hücre bulundu, alan boþ
            }
        }

        // Eðer boþ hücre bulunmazsa tüm hücreler dolu kabul edilir
        return false; // Tüm alan dolu
    }

    //Oyun sahnesinde etrafý görsel olarak çizmek için(isteðe baðlý)
    [SerializeField] private bool showGizmos;

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + boxCenter, boxSize); // Kontrol edilecek kutunun boyutunu gösterir
        }
    }
}