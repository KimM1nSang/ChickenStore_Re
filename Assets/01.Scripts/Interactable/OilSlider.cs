using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilSlider : SliderGimmick
{
    [SerializeField]
    private Image fillImage;
    protected override void OverrideUpdate()
    {
        base.OverrideUpdate();

        if(valPercet >= 70 && valPercet<= 90)
        {
            fillImage.color = Color.red;
        }
        else
        {
            fillImage.color = Color.white;
        }
    }
}
