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
                print("뿌링클 통에서 치킨을 뺐다.");
            }
            else
            {
                if (curPurrinkledChicken == null)
                {
                    curPurrinkledChicken = value;
                    print("뿌링클 통에 치킨을 넣었다.");
                    if (curPurrinkledChicken.ChickenType == ChickenType.FRIED)
                    {
                        curPurrinkledChicken.ChickenType = ChickenType.PURRINKLE;
                    }
                }
            }

        }
    }
}
