using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class GuestManager : MonoBehaviour
{
    public static GuestManager Instance;

    public Guest curGuest;
    public GameObject guestPrefab;
    public Transform windowTrm;

    public Text guestComment;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        CreateGuest();
        GuestCommentRefresh();
    }
    public void CreateGuest()
    {
        if(curGuest == null)
        {
            curGuest = Instantiate(guestPrefab, windowTrm).GetComponent<Guest>();
        }
        
        curGuest.SetUp();
        curGuest.GuestEnter(EnterComment);

    }
    public bool Offer()
    {
        if(curGuest != null)
        {
            if (curGuest.isArrive)
            {
                // ġŲ�� ���� �ֹ��� ������ Ʈ��
                // ġŲ�� ������������ ó��
                //curGuest.SetComment();
                guestComment.DOText(curGuest.ExitComment, 1).OnComplete(() => {
                    SaveManager.Instance.moneyData.AddGold(100);
                    GuestCommentRefresh();
                    curGuest.GuestExit(() => { CreateGuest(); });
                });
                return true;
            }
        }
        return false;
    }
    public void Complete(Action act = null)
    {
        // ġŲ�� ���� �ֹ��� ������ Ʈ��
        // ġŲ�� ������������ ó��
        //curGuest.SetComment();
        GuestCommentRefresh();

        guestComment.DOText(curGuest.ExitComment, 1).OnComplete(() => {
            act?.Invoke();
            GuestExit();
        });
    }
    public void EnterComment()
    {
        GuestCommentRefresh();

        guestComment.DOText(curGuest.EnterComment, 1).OnComplete(()=> { curGuest.canOffered = true; });
    }
    public void ShootGuest()
    {
        if (curGuest.canOffered && curGuest.isArrive)
        {
            GameManager.Instance.CameraShaking(2);

            curGuest.SetExitComment(ExitType.SHOOTED);
            Complete();
            curGuest.canOffered = false;
        }
    }

    public void GuestExit()
    {
        GuestCommentRefresh();
        curGuest.GuestExit(() => { CreateGuest(); });
    }
    public void GuestCommentRefresh()
    {
        guestComment.text = "";
    }
}
