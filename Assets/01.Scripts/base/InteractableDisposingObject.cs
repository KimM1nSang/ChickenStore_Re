using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class InteractableDisposingObject : MonoBehaviour
{
    protected GraphicRaycaster m_Raycaster;
    protected float maxDistance = 50;


    public GameObject currentDisposedObject = null;

    protected void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentDisposedObject == null)
        {
            CallOnKeyDown();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            CallOnKeyHolding();

        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && currentDisposedObject != null)
        {
            CallOnKeyUp();
        }
    }
    public abstract void CallOnKeyUp();
    public abstract void CallOnKeyHolding();
    public abstract void CallOnKeyDown();

}
