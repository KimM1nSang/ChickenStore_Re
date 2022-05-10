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
        curGuest.GuestEnter();

    }
    public bool Offer()
    {
        if(curGuest != null)
        {
            if (curGuest.isArrive)
            {
                // ġŲ�� ���� �ֹ��� ������ Ʈ��
                // ġŲ�� ������������ ó��
                guestComment.DOText(curGuest.ExitComment, 1).OnComplete(() => {
                    SaveManager.Instance.moneyData.AddGold(100);
                    GetNextGuest();
                });
                return true;
            }
        }
        return false;
    }
    public void GetNextGuest()
    {
       
        GuestCommentRefresh();
        curGuest.GuestExit(() => { CreateGuest(); });
    }
    public void GuestCommentRefresh()
    {
        guestComment.text = "";
    }
}
