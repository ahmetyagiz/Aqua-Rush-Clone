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
        // Her frame'de array'in kontrol edilmesini istiyorsan bu iþlemi Update'e koyabilirsin
        if (CheckIfAllNull())
        {
            WinTrigger();
        }
    }

    private bool CheckIfAllNull()
    {
        // Array'in tüm elemanlarýnýn null olup olmadýðýný kontrol eden fonksiyon
        foreach (GameObject obj in Characters)
        {
            if (obj != null)
            {
                return false; // Eðer array'de null olmayan bir eleman varsa oyunu kazanma
            }
        }
        return true; // Tüm elemanlar null ise kazanma koþulu saðlanýr
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