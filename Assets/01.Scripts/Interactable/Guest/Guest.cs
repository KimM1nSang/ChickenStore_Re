using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Guest : MonoBehaviour
{
    private RectTransform rt;
    public bool isArrive = false;
    public void SetUp()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(550,0);
    }
    public void GuestEnter()
    {
        rt.DOAnchorPosX(0,1).OnComplete(()=> { isArrive = true; });
    }
    public void GuestExit(Action act)
    {
        rt.DOAnchorPosX(-550, 1).OnComplete(()=> { act?.Invoke(); isArrive = false; });
    }
}
