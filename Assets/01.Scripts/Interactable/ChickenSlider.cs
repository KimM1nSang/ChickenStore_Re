using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class ChickenSlider : SliderGimmick
{
    [SerializeField]
    private Transform chickenSpawnTrm;
    [SerializeField]
    private GameObject chickenPrefab;
    [SerializeField]
    private SliderGimmick oilSliderObj;
    public override bool Action()
    {
        DefineAddValue(ref progressValue, progressMaxValue, addValue);
        if (progressValue >= progressMaxValue - addValue) 
        {
            if (oilSliderObj.valPercet >= 70  && oilSliderObj.valPercet <= 90)
            {
                Instantiate(chickenPrefab).transform.position = chickenSpawnTrm.position;
            }
            progressValue = 0;
            return true;
        }

        return false;
    }
    protected override void OverrideStart()
    {
        base.OverrideStart();
    }
    protected override void OverrideUpdate()
    {
       
    }
    
}
