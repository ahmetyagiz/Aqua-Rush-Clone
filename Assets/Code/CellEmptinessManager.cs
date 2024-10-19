using UnityEngine;

public class CellEmptinessManager : MonoBehaviour
{
    public GameObject gridCell;
    [SerializeField] private LayerMask gridLayer;

    private void Start()
    {
        SendRayToDown();
    }

    // Alttaki gridin al�nmas� i�in ray at�yorum.
    void SendRayToDown()
    {
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out RaycastHit hit, 5f, gridLayer))
        {
            gridCell = hit.collider.gameObject;
            gridCell.tag = "Cell_Full";
        }
    }

    // Hareket edince h�crenin tag'ini bo� yap�yorum.
    public void SetCellTagToEmpty()
    {
        gridCell.tag = "Cell_Empty";
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawRay(transform.position, Vector3.down);
    //}
}