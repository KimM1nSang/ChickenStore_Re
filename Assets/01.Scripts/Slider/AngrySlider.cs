using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AngrySlider : SliderGimmick
{

    protected override void OverrideStart()
    {
        base.OverrideStart();
    }
    
    protected override void OverrideUpdate()
    {
        if(GameManager.Instance.isSmartPhoneUse)
        {
            DefineSubValue(ref progressValue, subSpeed * Time.deltaTime);
        }
        else
        {
            DefineAddValue(ref progressValue, progressMaxValue, addValue * Time.deltaTime);
        }

        if(CheckFull() && !GameManager.Instance.isAngry)
        {
            StartCoroutine(AngryProcess());
        }

    }
    private IEnumerator AngryProcess()
    {
        GameManager.Instance.isAngry = true;

        while(!CheckEmpty())
        {
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
        GameManager.Instance.isAngry = false;
    }
    public override bool Action()
    {
        return false;
    }
}
