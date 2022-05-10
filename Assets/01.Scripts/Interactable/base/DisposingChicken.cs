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
        if (!EventSystem.current.IsPointerOverGameObject()) return;
        base.CallOnKeyDown();
        if (keyDownresults.Count <= 0) return;

        RaycastResult keyResult = keyDownresults[0];
        Button btn = keyResult.gameObject.GetComponent<Button>();

        if (btn == null&& keyResult.gameObject.CompareTag("Pickable") && keyDownresults.Count > 1)
        {
            RaycastResult keyResult2 = keyDownresults[1];

            FrieMachine frieMachine = keyResult2.gameObject.GetComponent<FrieMachine>();
            Refrigerator refrigerator = keyResult2.gameObject.GetComponent<Refrigerator>();

            if (frieMachine != null)
            {
                frieMachine.curFriedChicken = null;
            }
            if(refrigerator != null)
            {
                currentDisposedObject.transform.SetParent(chickenOriginalParentTrm);
            }
        }
    }
    public override void CallOnKeyUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) return;
        base.CallOnKeyUp();
        if (keyUpresults.Count > 1)
        {
            RaycastResult keyResult = keyUpresults[1];

            print(keyResult.gameObject.name);
            ChickenData chickenData = currentDisposedObject.GetComponent<ChickenData>();
            if(chickenData != null)
            {
                Guest guest = keyResult.gameObject.GetComponent<Guest>();
                FrieMachine frieMachine = keyResult.gameObject.GetComponent<FrieMachine>();
                Refrigerator refrigerator = keyResult.gameObject.GetComponent<Refrigerator>();
                if (guest != null)
                {
                    if (guest.canOffered && guest.isArrive)
                    {
                        // 치킨이 고객의 주문에 맞으면 트루
                        // 치킨을 제공했을때의 처리

                        if (chickenData.chickenType == guest.wishChicken)
                        {
                            guest.SetExitComment(ExitType.POSITIVE);
                        }
                        else
                        {
                            guest.SetExitComment(ExitType.NEGATIVE);
                        }
                        GuestManager.Instance.Complete(() => {
                            SaveManager.Instance.moneyData.AddGold(chickenData.Price);
                        });
                        Destroy(currentDisposedObject.gameObject);
                        guest.canOffered = false;

                    }

                }

                if (frieMachine != null)
                {
                    frieMachine.curFriedChicken = chickenData;
                    currentDisposedObject.transform.position = frieMachine.transform.position;
                }
                if(refrigerator != null)
                {
                    currentDisposedObject.gameObject.transform.SetParent(refrigerator.container);
                }
            }    
            
         
        }
        var ped = new PointerEventData(null);
        ped.position = lastPos;
        keyUpresults = new List<RaycastResult>();
        m_Raycaster.Raycast(ped, keyUpresults);
        // 이벤트 처리부분
        
        if (keyUpresults.Count > 1)
        {
                print("AAA");
            RaycastResult keyResult = keyUpresults[1];
            Refrigerator refrigerator = keyResult.gameObject.GetComponent<Refrigerator>();

            if (refrigerator != null)
            {
                print("CCCC");
                currentDisposedObject.gameObject.transform.SetParent(refrigerator.container);
            }
        }
        currentDisposedObject = null;

    }
}
