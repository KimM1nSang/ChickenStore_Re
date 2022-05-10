using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Guest : MonoBehaviour
{
    private RectTransform rt;
    public bool isArrive = false;
    public bool isOffered = false;

    private string[] exitComments  = {
        "잘 놀다 갑니다.",
        "맛있게 먹었어요!",
        "마왕도 인정하는 이맛",
        "맛있는 사랑 많관부",
        "내가 이 치킨을 다시 맛볼줄이야 ㅠㅠ",
        "오이오이 가게 다시 열줄 알았다고"
    };

    public string ExitComment;
    
    public void SetUp()
    {
        isOffered = false;
        ExitComment = exitComments[UnityEngine.Random.Range(0, exitComments.Length)];
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
