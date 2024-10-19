using System.Collections.Generic;
using UnityEngine;

public class FrontCellManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> FrontCells;

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