using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilTempSlider : SliderGimmick
{
    public Image sliderFill;
    protected override void OverrideUpdate()
    {
        base.OverrideUpdate();
        if (!GameManager.Instance.isPlayerAngry)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (Action())
                {

                }
            }

        }

        if(valPercet >= 90)
        {
            sliderFill.color = Color.red;
        }
        else
        {
            sliderFill.color = Color.white;
        }

    }
}
