using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChickenType
{
    RAW, // 10원
    FRIED, // 100 원
    SAUCED, // 150원
    PURRINKLE // 200원
}
public class ChickenData : MonoBehaviour
{
    [SerializeField]
    private ChickenType chickenType;
    public ChickenType ChickenType
    {
        get
        {
            return chickenType;
        }
        set
        {
            chickenType = value;
            RefreshChicken();
        }
    }
    public float Price;

    private Image chickenImage;
    public void SetUp(ChickenType chickenType)
    {
        chickenImage = GetComponent<Image>();
        this.ChickenType = chickenType;
    }
    public void RefreshChicken()
    {
        switch (ChickenType)
        {
            case ChickenType.RAW:
                Price = 10;
                chickenImage.sprite = Resources.Load<Sprite>("RawChicken");
                break;
            case ChickenType.FRIED:
                Price = 100;
                chickenImage.sprite = Resources.Load<Sprite>("Chicken");
                break;
            case ChickenType.SAUCED:
                Price = 150;
                chickenImage.sprite = Resources.Load<Sprite>("Chicken");
                break;
            case ChickenType.PURRINKLE:
                Price = 200;
                chickenImage.sprite = Resources.Load<Sprite>("Chicken");
                break;
            default:
                break;
        }
    }
}
