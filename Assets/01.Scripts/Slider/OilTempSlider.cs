using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilTempSlider : SliderGimmick
{
    public Image sliderFill;
    public bool canFrieTemp =false;
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
            canFrieTemp = false;
        }
        else if(valPercet <= 30)
        {
            sliderFill.color = Color.red;
            canFrieTemp = false;
        }
        else
        {
            sliderFill.color = Color.white;
            canFrieTemp = true;
        }

    }
}
