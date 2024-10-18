using System;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum StickmanColor
    {
        Orange,
        Green,
        Blue,
        Yellow
    }

    [SerializeField] private List<bool> orangeColors;
    [SerializeField] private List<bool> greenColors;
    [SerializeField] private List<bool> blueColors;
    [SerializeField] private List<bool> yellowColors;

    public static ColorManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Tekil örneði bu bileþen olarak ayarla
        Instance = this;
    }

    public void IncreaseColorListCount(Enum stickmanColor)
    {
        switch (stickmanColor)
        {
            case StickmanColor.Orange:
                
                break;
            case StickmanColor.Green:
                break;
            case StickmanColor.Blue:
                break;
            case StickmanColor.Yellow:
                break;
            default:
                break;
        }
    }
}