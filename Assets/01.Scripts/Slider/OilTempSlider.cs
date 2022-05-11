using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilTempSlider : SliderGimmick
{
    public Image sliderFill;

    private float maxVal = 90;
    private float minVal = 30;

    public float SubSpeedOrigin { get; private set; } = 2.5f;
    public float SubSpeedWithChicken { get; private set; } = 5;
    protected override void OverrideStart()
    {
        base.OverrideStart();
        SubSpeed = SubSpeedOrigin;
    }
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

        if(valPercet >= maxVal)
        {
            sliderFill.color = Color.red;
        }
        else if(valPercet <= minVal)
        {
            sliderFill.color = Color.red;
        }
        else
        {
            sliderFill.color = Color.white;
        }

    }

    public bool CanFrie()
    {
        return valPercet < maxVal && valPercet > minVal;
    }
}
