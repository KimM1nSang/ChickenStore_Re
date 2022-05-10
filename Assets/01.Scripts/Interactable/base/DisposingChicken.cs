using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisposingChicken : InteractableUIDisposingObject
{
    public override void CallOnKeyUp()
    {
        base.CallOnKeyUp();
        if (keyUpresults.Count > 1)
        {
            RaycastResult keyResult = keyUpresults[1];

            print(keyResult.gameObject.name);
            Guest guest = keyResult.gameObject.GetComponent<Guest>();
            if (guest != null)
            {
                if(guest.canOffered&& guest.isArrive)
                {

                    // 치킨이 고객의 주문에 맞으면 트루
                    // 치킨을 제공했을때의 처리

                    ChickenData chickenData = currentDisposedObject.GetComponent<ChickenData>();
                    if (chickenData.chickenType == guest.wishChicken)
                    {
                        guest.SetExitComment(ExitType.POSITIVE);
                    }
                    else
                    {
                        guest.SetExitComment(ExitType.NEGATIVE);
                    }
                    GuestManager.Instance.Complete(()=> {
                        SaveManager.Instance.moneyData.AddGold(chickenData.Price);
                    });
                    Destroy(currentDisposedObject.gameObject);
                    guest.canOffered = false;

                }

            }
         
        }
        currentDisposedObject = null;

    }
}
