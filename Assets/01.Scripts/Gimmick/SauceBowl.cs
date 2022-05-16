using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceBowl : MonoBehaviour
{
    [SerializeField]
    private ChickenData curSaucedChicken;
    public ChickenData CurSaucedChicken
    {
        get
        {
            return curSaucedChicken;
        }
        set
        {


            if (value == null)
            {
                curSaucedChicken = value;
                print("�ҽ��뿡�� ġŲ�� ����.");
            }
            else
            {
                if (curSaucedChicken == null)
                {
                    curSaucedChicken = value;
                    print("�ҽ��뿡 ġŲ�� �־���.");
                    if(curSaucedChicken.ChickenType == ChickenType.FRIED)
                    {
                        curSaucedChicken.ChickenType = ChickenType.SAUCED;
                    }
                }
            }

        }
    }
}
