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
                print("소스통에서 치킨을 뺐다.");
            }
            else
            {
                if (curSaucedChicken == null)
                {
                    curSaucedChicken = value;
                    print("소스통에 치킨을 넣었다.");
                    if(curSaucedChicken.ChickenType == ChickenType.FRIED)
                    {
                        curSaucedChicken.ChickenType = ChickenType.SAUCED;
                    }
                }
            }

        }
    }
}
