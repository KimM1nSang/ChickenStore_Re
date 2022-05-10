using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Guest : MonoBehaviour
{
    RectTransform rt;
    public void SetUp()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(550,0);
    }
    public void GuestEnter()
    {
        rt.DOAnchorPosX(0,1);
    }
    public void GuestExit(Action act)
    {
        rt.DOAnchorPosX(-550, 1).OnComplete(()=> { act?.Invoke(); });
    }
    public void GuestExit()
    {
        rt.DOAnchorPosX(-550, 1);
    }
}
