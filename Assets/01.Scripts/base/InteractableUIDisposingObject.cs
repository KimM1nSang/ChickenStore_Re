using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InteractableUIDisposingObject : InteractableDisposingObject
{
    protected List<RaycastResult> keyUpresults;
    protected List<RaycastResult> keyDownresults;

    protected Vector3 lastPos;
    public override void CallOnKeyDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) return;

        var ped = new PointerEventData(null);
        ped.position = Input.mousePosition;
        keyDownresults = new List<RaycastResult>();
        m_Raycaster.Raycast(ped, keyDownresults);

        if (keyDownresults.Count <= 0) return;
        // 이벤트 처리부분
        //Debug.Log(results[0].gameObject.name);
        //ItemData itemData = results[0].gameObject.GetComponent<CookingMaterialItem>().data;
        RaycastResult keyResult = keyDownresults[0];
        Button btn = keyResult.gameObject.GetComponent<Button>();

        
        if (btn == null && keyResult.gameObject.CompareTag("Pickable"))
        {
            currentDisposedObject = keyDownresults[0].gameObject;
            lastPos = currentDisposedObject.transform.GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public override void CallOnKeyHolding()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePos = Input.mousePosition;
            if (currentDisposedObject != null)
                currentDisposedObject.transform.position = mousePos;
        }
    }

    public override void CallOnKeyUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) return;

        var ped = new PointerEventData(null);
        ped.position = Input.mousePosition;
        keyUpresults = new List<RaycastResult>();
        m_Raycaster.Raycast(ped, keyUpresults);

        if (keyUpresults.Count <= 0) return;
        // 이벤트 처리부분
        Debug.Log(keyUpresults[0].gameObject.name);
        if (keyUpresults.Count > 1)
        {
            if(!keyUpresults[1].gameObject.CompareTag("Dropable"))
            {
                currentDisposedObject.transform.GetComponent<RectTransform>().anchoredPosition = lastPos;
            }
        }
        else
        {
            currentDisposedObject.transform.GetComponent<RectTransform>().anchoredPosition = lastPos;
        }
    }
}
