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
    public ChickenType chickenType;
    public float Price;

    private Image chickenImage;
    public void SetUp(ChickenType chickenType)
    {
        this.chickenType = chickenType;
        chickenImage = GetComponent<Image>();
        RefreshChicken();
    }
    public void RefreshChicken()
    {
        switch (chickenType)
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
