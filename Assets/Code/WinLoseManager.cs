using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    public static WinLoseManager Instance;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private GameObject[] Characters;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Characters = GameObject.FindGameObjectsWithTag("Character");
    }

    void Update()
    {
        // Her frame'de array'in kontrol edilmesini istiyorsan bu i�lemi Update'e koyabilirsin
        if (CheckIfAllNull())
        {
            WinTrigger();
        }
    }

    private bool CheckIfAllNull()
    {
        // Array'in t�m elemanlar�n�n null olup olmad���n� kontrol eden fonksiyon
        foreach (GameObject obj in Characters)
        {
            if (obj != null)
            {
                return false; // E�er array'de null olmayan bir eleman varsa oyunu kazanma
            }
        }
        return true; // T�m elemanlar null ise kazanma ko�ulu sa�lan�r
    }

    public void WinTrigger()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoseTrigger()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}