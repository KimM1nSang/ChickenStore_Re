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
        "�� ��� ���ϴ�.",
        "���ְ� �Ծ����!",
        "���յ� �����ϴ� �̸�",
        "���� �� ġŲ�� �ٽ� �������̾� �Ф�",
        "���̿��� ���� �ٽ� ���� �˾Ҵٰ�"
    };
    
    private string[] negativeExitComments  = {
        "���� �Ը� ���ȳ�",
        "1�� �帮�ڽ��ϴ�",
        "���γ׿�"
    };

    private string[] shootedExitComments = {
        "����",
        "���� ��ٴ�!"
    };
    private string[][] enterComments = {
        new string[] // ����
        {
            "���� �ֽÿ�",
            "���� �԰���� ���̳׿�",
            "�̽��Ѱ� �԰� �;��",
            "Ƣ���� ������ �ּ���",
            "��...����....",
            "�ƹ��� ������ ���� ������"
        },
        new string[] // �����̵�
        {
            "Ƣ���ֽÿ�",
            "��rrr���̵� �ּ���",
            "ġŲ�� ������������!",
            "��@~��%#.��@�°ɷ�.���@#!",
            "�� ���������� ������"
        },
        new string[] // ���
        {
            "������ �ֽÿ�"
        },
        new string[] // �Ѹ�Ŭ
        {
            "���� �Ѹ��� �ֽÿ�"
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
