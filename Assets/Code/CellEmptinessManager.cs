using UnityEngine;
using UnityEngine.AI;

public class CellEmptinessManager : MonoBehaviour
{
    [HideInInspector] public GameObject gridCell;
    [SerializeField] private LayerMask gridLayer;

    private void Start()
    {
        SendRayToDown();
    }

    // Alttaki gridin alýnmasý için ray atýyorum.
    void SendRayToDown()
    {
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out RaycastHit hit, 5f, gridLayer))
        {
            gridCell = hit.collider.gameObject;
            gridCell.tag = "Cell_Full";

            NavMeshObstacle navMeshObstacle = gridCell.AddComponent<NavMeshObstacle>();
            navMeshObstacle.center = Vector3.zero;
            navMeshObstacle.size = new Vector3(1f, 0.2f, 0.1f);
            navMeshObstacle.carving = true;
        }
    }

    // Hareket edince hücrenin tag'ini boþ yapýyorum.
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