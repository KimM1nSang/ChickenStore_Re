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
            // ġŲ�� ���� �ֹ��� ������ Ʈ��
            // ġŲ�� ������������ ó��
            curGuest.GuestExit(() => { CreateGuest(); });

            return true;
        }
        else
        {
            return false;
        }
    }
}
