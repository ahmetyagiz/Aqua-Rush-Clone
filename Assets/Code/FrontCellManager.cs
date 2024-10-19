using System.Collections;
using System.Linq;
using UnityEngine;

public class FrontCellManager : MonoBehaviour
{
    private GameObject[] FrontCells;
    private Coroutine loseCheckCoroutine;  // Saya� i�in coroutine
    private float loseTimer = 0f;
    private float loseThreshold = 3f;  // 3 saniye boyunca dolu kontrol�
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

    public bool IsAnyFrontCellEmpty()
    {
        foreach (GameObject frontCell in FrontCells)
        {
            if (frontCell.CompareTag("FrontCell_Empty"))
            {
                return true;
            }
        }

        // E�er bo� h�cre bulunmazsa t�m h�creler dolu kabul edilir
        return false;
    }

    public bool IsAllCellFull()
    {
        foreach (GameObject frontCell in FrontCells)
        {
            if (frontCell.CompareTag("FrontCell_Empty"))
            {
                return false;
            }
        }

        // E�er bo� h�cre bulunmazsa t�m h�creler dolu kabul edilir
        return true;
    }

    private void Update()
    {
        // Her karede h�creleri kontrol et
        if (IsAllCellFull())
        {
            if (loseCheckCoroutine == null)
            {
                loseCheckCoroutine = StartCoroutine(CheckLoseCondition());
            }
        }
        else
        {
            if (loseCheckCoroutine != null)
            {
                StopCoroutine(loseCheckCoroutine);
                loseCheckCoroutine = null;
                loseTimer = 0f;  // Saya� s�f�rlan�r
            }
        }
    }

    private IEnumerator CheckLoseCondition()
    {
        while (loseTimer < loseThreshold)
        {
            loseTimer += Time.deltaTime;
            yield return null;
        }

        // E�er saya� dolarsa oyunu kaybettir
        WinLoseManager.Instance.LoseTrigger();
    }
}