using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SlidingObject : MonoBehaviour
{
    public Button activeButton;
    private RectTransform rt;

    [SerializeField]
    private float activeSpeed = .5f;
    [SerializeField]
    private bool isActive = false;

    public Vector2 activePos;
    public Vector2 unActivePos;

    protected virtual void Start()
    {
        rt = GetComponent<RectTransform>();
        DayManager.Instance.OnChangeDay += CallOnChangeDay;

        activeButton.onClick.AddListener(()=> {
            if(!GameManager.Instance.isPlayerAngry && !GameManager.Instance.isSmartPhoneUse)
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
        });
    }
    public virtual void CallOnChangeDay()
    {
        rt.DOAnchorPos(unActivePos, activeSpeed);
    }
}
