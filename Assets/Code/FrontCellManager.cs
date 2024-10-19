using System.Linq;
using UnityEngine;

public class FrontCellManager : MonoBehaviour
{
    private GameObject[] FrontCells;

    public static FrontCellManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        GetAllFrontCells();
    }

    void GetAllFrontCells()
    {
        FrontCells = GameObject.FindGameObjectsWithTag("FrontCell_Empty");
        FrontCells = FrontCells.OrderBy(cell => cell.transform.position.x).ToArray();
    }

    public Transform GetEmptyFrontCell()
    {
        foreach (GameObject frontCell in FrontCells)
        {
            if (frontCell.CompareTag("FrontCell_Empty"))
            {
                frontCell.tag = "FrontCell_Full";
                return frontCell.transform;
            }
        }

        return null;
    }
}