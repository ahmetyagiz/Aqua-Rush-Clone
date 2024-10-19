using System;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    public static WinLoseManager Instance;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    [SerializeField]
    private int
        blueCount,
        greenCount,
        orangeCount,
        purpleCount,
        redCount,
        yellowCount;

    public void IncreaseColorCount(Enum colorType)
    {
        switch (colorType)
        {
            case ColorType.Blue:
                blueCount++;
                break;
            case ColorType.Green:
                greenCount++;
                break;
            case ColorType.Orange:
                orangeCount++;
                break;
            case ColorType.Purple:
                purpleCount++;
                break;
            case ColorType.Red:
                redCount++;
                break;
            case ColorType.Yellow:
                yellowCount++;
                break;
            default:
                // code block
                break;
        }
    }
}