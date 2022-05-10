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
                if (GuestManager.Instance.Offer())
                {
                    Destroy(currentDisposedObject.gameObject);
                }
            }
         
        }
        currentDisposedObject = null;

    }
}
