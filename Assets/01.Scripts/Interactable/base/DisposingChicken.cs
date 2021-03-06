using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisposingChicken : InteractableUIDisposingObject
{
    public Transform chickenOriginalParentTrm;
    public override void CallOnKeyDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() || GameManager.Instance.isPlayerAngry) return;
        base.CallOnKeyDown();
        if (keyDownresults.Count <= 0) return;

        RaycastResult keyResult = keyDownresults[0];

        foreach (RaycastResult item in keyDownresults)
        {
            Button btn = item.gameObject.GetComponent<Button>();
            if (btn == null && item.gameObject.CompareTag("Pickable") && keyDownresults.Count > 1)
            {
                RaycastResult keyResult2 = keyDownresults[1];

                FrieMachine frieMachine = keyResult2.gameObject.GetComponent<FrieMachine>();
                SauceBowl sauceBowl = keyResult2.gameObject.GetComponent<SauceBowl>();

                if (frieMachine != null)
                {
                    frieMachine.CurFriedChicken = null;
                }
                if (sauceBowl != null)
                {
                    sauceBowl.CurSaucedChicken = null;
                }
                currentDisposedObject.transform.SetParent(chickenOriginalParentTrm);
                break;
            }
        }
       
    }
    public override void CallOnKeyHolding()
    {
        if (GameManager.Instance.isPlayerAngry) return;
        base.CallOnKeyHolding();
    }
    public override void CallOnKeyUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject() || GameManager.Instance.isPlayerAngry) return;
        base.CallOnKeyUp();
        if (keyUpresults.Count > 1)
        {
            RaycastResult keyResult = keyUpresults[1];

            //print(keyResult.gameObject.name);
            ChickenData chickenData = currentDisposedObject.GetComponent<ChickenData>();
            if(chickenData != null)
            {
                Guest guest = keyResult.gameObject.GetComponent<Guest>();
                FrieMachine frieMachine = keyResult.gameObject.GetComponent<FrieMachine>();
                SauceBowl sauceBowl = keyResult.gameObject.GetComponent<SauceBowl>();
                Refrigerator refrigerator = keyResult.gameObject.GetComponent<Refrigerator>();
                if (guest != null)
                {
                    if (guest.canOffered && guest.isArrive)
                    {
                        // ?????? ?????? ?????? ?????? ????
                        // ?????? ???????????? ????

                        if (chickenData.ChickenType == guest.wishChicken)
                        {
                            guest.SetExitComment(ExitType.POSITIVE);
                        }
                        else
                        {
                            guest.SetExitComment(ExitType.NEGATIVE);
                        }
                        GuestManager.Instance.Complete(() => {
                            if (chickenData.ChickenType == guest.wishChicken)
                            {
                                SaveManager.Instance.moneyData.AddGold(chickenData.Price);
                                SaveManager.Instance.moneyData.AddRepute(5);
                            }
                            else
                            {
                                SaveManager.Instance.moneyData.SubRepute(10);
                            }
                        });
                        GameManager.Instance.makedChickenList.Remove(chickenData);
                        Destroy(currentDisposedObject.gameObject);

                    }

                }

                if (frieMachine != null)
                {
                    frieMachine.CurFriedChicken = chickenData;
                    currentDisposedObject.transform.position = frieMachine.transform.position;
                } 
                if (sauceBowl != null)
                {
                    sauceBowl.CurSaucedChicken = chickenData;
                    currentDisposedObject.transform.position = sauceBowl.transform.position;
                }
                if(refrigerator != null)
                {
                    currentDisposedObject.gameObject.transform.SetParent(refrigerator.container);
                }

            }


        }
        lastPos = currentDisposedObject.transform.position;
        var ped = new PointerEventData(null);
        ped.position = lastPos;
        keyUpresults = new List<RaycastResult>();
        m_Raycaster.Raycast(ped, keyUpresults);
        // ?????? ????????
        
        if (keyUpresults.Count > 1)
        {
            RaycastResult keyResult = keyUpresults[1];
            Refrigerator refrigerator = keyResult.gameObject.GetComponent<Refrigerator>();

            if (refrigerator != null)
            {
                currentDisposedObject.gameObject.transform.SetParent(refrigerator.container);
                print("????");
            }
        }
        currentDisposedObject = null;

    }
}
