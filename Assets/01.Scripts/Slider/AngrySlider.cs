using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
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
            DefineSubValue(ref progressValue, SubSpeed * Time.deltaTime);
        }
        else
        {
            if(!GameManager.Instance.isPlayerAngry)
            {
                DefineAddValue(ref progressValue, progressMaxValue, addValue * Time.deltaTime);
            }
        }

        if(CheckFull() && !GameManager.Instance.isPlayerAngry)
        {
            Timing.RunCoroutine(AngryProcess());
        }

    }
    private IEnumerator<float> AngryProcess()
    {
        GameManager.Instance.isPlayerAngry = true;

        while(!CheckEmpty())
        {
            yield return Timing.WaitForOneFrame;
        }

        yield return Timing.WaitForOneFrame;
        GameManager.Instance.isPlayerAngry = false;
    }
    public override bool Action()
    {
        return false;
    }
}
