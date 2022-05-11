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

    public Action OnGuestExit;
    public Action OnGuestEnter;
    public Action OnGuestOffered;

    public bool isGuestAngry;
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
        curGuest.GuestEnter(()=> { EnterComment(); OnGuestEnter?.Invoke(); });

    }
    public bool Offer()
    {
        if(curGuest != null)
        {
            if (curGuest.isArrive)
            {
                // 치킨이 고객의 주문에 맞으면 트루
                // 치킨을 제공했을때의 처리
                OnGuestOffered?.Invoke();
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
        GuestCommentRefresh();

        OnGuestOffered?.Invoke();

        guestComment.DOText(curGuest.ExitComment, 1).OnComplete(() => {
            OnGuestExit?.Invoke();
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
            ShootManager shootManager = FindObjectOfType<ShootManager>();
            if(shootManager != null)
            {
                if (shootManager.Shoot())
                {
                    GameManager.Instance.CameraShaking(2);
                    curGuest.SetExitComment(ExitType.SHOOTED);
                    Complete();
                    curGuest.canOffered = false;
                    isGuestAngry = false;
                }
            }
           

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
