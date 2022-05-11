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

        foreach (RaycastResult item in keyDownresults)
        {
            Button btn = item.gameObject.GetComponent<Button>();
            if (btn == null && item.gameObject.CompareTag("Pickable") && keyDownresults.Count > 1)
            {
                RaycastResult keyResult2 = keyDownresults[1];

                FrieMachine frieMachine = keyResult2.gameObject.GetComponent<FrieMachine>();

                if (frieMachine != null)
                {
                    frieMachine.CurFriedChicken = null;
                }
                currentDisposedObject.transform.SetParent(chickenOriginalParentTrm);
                break;
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

            //print(keyResult.gameObject.name);
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
                        // ġŲ�� ���� �ֹ��� ������ Ʈ��
                        // ġŲ�� ������������ ó��

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
                                SaveManager.Instance.moneyData.AddGold(chickenData.Price);
                        });
                        GameManager.Instance.makedChickenList.Remove(chickenData);
                        Destroy(currentDisposedObject.gameObject);
                        guest.canOffered = false;

                    }

                }

                if (frieMachine != null)
                {
                    frieMachine.CurFriedChicken = chickenData;
                    currentDisposedObject.transform.position = frieMachine.transform.position;
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
        // �̺�Ʈ ó���κ�
        
        if (keyUpresults.Count > 1)
        {
            RaycastResult keyResult = keyUpresults[1];
            Refrigerator refrigerator = keyResult.gameObject.GetComponent<Refrigerator>();

            if (refrigerator != null)
            {
                currentDisposedObject.gameObject.transform.SetParent(refrigerator.container);
                print("����");
            }
        }
        currentDisposedObject = null;

    }
}
