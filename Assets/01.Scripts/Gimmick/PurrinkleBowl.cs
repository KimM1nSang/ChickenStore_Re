using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurrinkleBowl : MonoBehaviour
{

    [SerializeField]
    private ChickenData curPurrinkledChicken;
    public ChickenData CurPurrinkledChicken
    {
        get
        {
            return curPurrinkledChicken;
        }
        set
        {


            if (value == null)
            {
                curPurrinkledChicken = value;
                print("�Ѹ�Ŭ �뿡�� ġŲ�� ����.");
            }
            else
            {
                if (curPurrinkledChicken == null)
                {
                    curPurrinkledChicken = value;
                    print("�Ѹ�Ŭ �뿡 ġŲ�� �־���.");
                    if (curPurrinkledChicken.ChickenType == ChickenType.FRIED)
                    {
                        curPurrinkledChicken.ChickenType = ChickenType.PURRINKLE;
                    }
                }
            }

        }
    }
}
