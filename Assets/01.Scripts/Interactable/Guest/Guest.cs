using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public enum ExitType
{
    POSITIVE,
    NEGATIVE,
    SHOOTED
}
public class Guest : MonoBehaviour
{
    private RectTransform rt;
    public bool isArrive = false;
    public bool canOffered = false;
  
    
    private string[] positiveExitComments  = {
        "잘 놀다 갑니다.",
        "맛있게 먹었어요!",
        "마왕도 인정하는 이맛",
        "내가 이 치킨을 다시 맛볼줄이야 ㅠㅠ",
        "오이오이 가게 다시 열줄 알았다고"
    };
    
    private string[] negativeExitComments  = {
        "에잇 입맛 버렸네",
        "1점 드리겠습니다",
        "별로네요"
    };

    private string[] shootedExitComments = {
        "으악",
        "총을 쏘다니!"
    };
    private string[][] enterComments = {
        new string[] // 날것
        {
            "날것 주시오",
            "날로 먹고싶은 날이네요",
            "싱싱한게 먹고 싶어요",
            "튀기지 않은거 주세요",
            "피...생살....",
            "아무런 조리도 하지 않은것"
        },
        new string[] // 프라이드
        {
            "튀겨주시오",
            "프rrr라이드 주세용",
            "치킨은 오리지널이지!",
            "근@~본%#.있@는걸로.줘봐@#!",
            "난 오리지널이 좋더라"
        },
        new string[] // 양념
        {
            "빨간거 주시오"
        },
        new string[] // 뿌링클
        {
            "가루 뿌린거 주시오"
        },
    };
   

    public string EnterComment;

    public string ExitComment;

    public ChickenType wishChicken = ChickenType.FRIED;
    public void SetUp()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(550,0);

        Array values = Enum.GetValues(typeof(ChickenType));
        int chickenTypeNum = UnityEngine.Random.Range(0, GameManager.Instance.Difficulty +1);
        wishChicken = (ChickenType)values.GetValue(chickenTypeNum);
        EnterComment = enterComments[(int)wishChicken][UnityEngine.Random.Range(0, enterComments[(int)wishChicken].Length)];
    }

    public void SetExitComment(string exitComment)
    {
        ExitComment = "";
        ExitComment += exitComment;
    }
    public void SetExitComment(ExitType exitType)
    {
        switch (exitType)
        {
            case ExitType.POSITIVE:
                ExitComment = positiveExitComments[UnityEngine.Random.Range(0, positiveExitComments.Length)];
                break;
            case ExitType.NEGATIVE:
                ExitComment = negativeExitComments[UnityEngine.Random.Range(0, negativeExitComments.Length)];
                break;
            case ExitType.SHOOTED:
                ExitComment = shootedExitComments[UnityEngine.Random.Range(0, shootedExitComments.Length)];
                break;
            default:
                break;
        }

    }


    public void GuestEnter(Action act)
    {
        rt.DOAnchorPosX(0,1).OnComplete(()=> { act?.Invoke(); isArrive = true; });
    }
    public void GuestExit(Action act)
    {
        rt.DOAnchorPosX(-550, 1).OnComplete(()=> { act?.Invoke(); isArrive = false; });
    }
}
