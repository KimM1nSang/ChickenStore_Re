using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuestManager : MonoBehaviour
{
    public static GuestManager Instance;

    public Guest curGuest;
    public GameObject guestPrefab;
    public Transform windowTrm;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        CreateGuest();
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
            // 치킨이 고객의 주문에 맞으면 트루
            // 치킨을 제공했을때의 처리
            curGuest.GuestExit(() => { CreateGuest(); });

            return true;
        }
        else
        {
            return false;
        }
    }
}
