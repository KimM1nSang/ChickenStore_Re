using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SlidingObject : MonoBehaviour
{
    public Button activeButton ;
    protected RectTransform rt;
    protected Action act;

    [SerializeField]
    protected float activeSpeed = .5f;
    [SerializeField]
    protected bool isActive = false;

    public Vector2 activePos;
    public Vector2 unActivePos;

    protected virtual void Start()
    {
        rt = GetComponent<RectTransform>();
        DayManager.Instance.OnChangeDay += CallOnChangeDay;
        OverridedStart();
    }
    protected virtual void OverridedStart()
    {
        act = () => {
            ActiveSliding();
        };
        if (activeButton != null)
        {
            activeButton.onClick.AddListener(() => {
                act?.Invoke();
            });
        }
    }

    public virtual void ActiveSliding()
    {
        if (!GameManager.Instance.isPlayerAngry && !GameManager.Instance.isSmartPhoneUse)
        {
            if (isActive)
            {
                rt.DOAnchorPos(unActivePos, activeSpeed);
            }
            else
            {
                rt.DOAnchorPos(activePos, activeSpeed);
            }
            isActive = !isActive;
        }
    }
    public virtual void CallOnChangeDay()
    {
        rt.DOAnchorPos(unActivePos, activeSpeed);
    }
}
