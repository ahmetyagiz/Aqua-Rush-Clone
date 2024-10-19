using System;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    public static WinLoseManager Instance;

    public List<GameObject>
        BluesOnFrontCell,
        GreensOnFrontCell,
        OrangesOnFrontCell,
        PurplesOnFrontCell,
        RedsOnFrontCell,
        YellowsOnFrontCell;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddCharacterToList(Enum colorType, GameObject character)
    {
        switch (colorType)
        {
            case ColorType.Blue:
                BluesOnFrontCell.Add(character);
                if (BluesOnFrontCell.Count >= 3)
                {
                    foreach (GameObject c in BluesOnFrontCell)
                    {
                        c.GetComponent<Character>().MoveToLevelEndTargetTrigger();
                    }
                    BluesOnFrontCell.Clear();
                }
                break;
            case ColorType.Green:
                GreensOnFrontCell.Add(character);
                if (GreensOnFrontCell.Count >= 3)
                {
                    foreach (GameObject c in GreensOnFrontCell)
                    {
                        c.GetComponent<Character>().MoveToLevelEndTargetTrigger();
                    }
                    GreensOnFrontCell.Clear();
                }
                break;
            case ColorType.Orange:
                OrangesOnFrontCell.Add(character);
                if (OrangesOnFrontCell.Count >= 3)
                {
                    foreach (GameObject c in OrangesOnFrontCell)
                    {
                        c.GetComponent<Character>().MoveToLevelEndTargetTrigger();
                    }
                    OrangesOnFrontCell.Clear();
                }
                break;
            case ColorType.Purple:
                PurplesOnFrontCell.Add(character);
                if (PurplesOnFrontCell.Count >= 3)
                {
                    foreach (GameObject c in PurplesOnFrontCell)
                    {
                        c.GetComponent<Character>().MoveToLevelEndTargetTrigger();
                    }
                    PurplesOnFrontCell.Clear();
                }
                break;
            case ColorType.Red:
                RedsOnFrontCell.Add(character);
                if (RedsOnFrontCell.Count >= 3)
                {
                    foreach (GameObject c in RedsOnFrontCell)
                    {
                        c.GetComponent<Character>().MoveToLevelEndTargetTrigger();
                    }
                    RedsOnFrontCell.Clear();
                }
                break;
            case ColorType.Yellow:
                YellowsOnFrontCell.Add(character);
                if (YellowsOnFrontCell.Count >= 3)
                {
                    foreach (GameObject c in YellowsOnFrontCell)
                    {
                        c.GetComponent<Character>().MoveToLevelEndTargetTrigger();
                    }
                    YellowsOnFrontCell.Clear();
                }
                break;
            default:
                // code block
                break;
        }
    }
}