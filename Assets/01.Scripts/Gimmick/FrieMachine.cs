using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class FrieMachine : MonoBehaviour
{
    [field: SerializeField]
    public OilTempSlider oilTempSlider { get; private set; }


    [SerializeField]
    private ChickenData curFriedChicken;

    public ChickenData CurFriedChicken
    {
        get
        {
            return curFriedChicken;
        }
        set
        {
            

            if (value == null)
            {
                curFriedChicken = value;
                print("Ƣ��⿡�� ġŲ�� ����.");
                oilTempSlider.SubSpeed = oilTempSlider.SubSpeedOrigin;
            }
            else
            {
                if (curFriedChicken == null)
                {
                    curFriedChicken = value;
                    print("Ƣ��⿡ ġŲ�� �־���.");
                    Timing.RunCoroutine(PutIn(), "PuIn");
                    oilTempSlider.SubSpeed = oilTempSlider.SubSpeedWithChicken;
                }
            }

        }
    }

    private IEnumerator<float> PutIn()
    {
        float num = 0;
        while (num < 2)
        {
            if (curFriedChicken == null)
            {
                print("Ƣ��⿡ ġŲ�� ����");
                yield break;
            }
            yield return Timing.WaitForOneFrame;
            if (oilTempSlider.CanFrie())
            {
                num += Time.deltaTime;
            }
            else
            {
                num = 0;
            }
        }

        if (curFriedChicken != null)
        {
            switch (curFriedChicken.ChickenType)
            {
                case ChickenType.RAW:
                    curFriedChicken.ChickenType = ChickenType.FRIED;
                    break;
                case ChickenType.FRIED:
                    break;
                case ChickenType.SAUCED:
                    break;
                case ChickenType.PURRINKLE:
                    break;
                default:
                    break;
            }
        }
    }
}
