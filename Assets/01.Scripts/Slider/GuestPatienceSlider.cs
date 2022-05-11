using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using static Define;

public class GuestPatienceSlider : SliderGimmick
{
    public bool isActive = false;
    private bool isRunCor = false;
    [SerializeField]
    private Canvas guestAngryCanvas;
    [SerializeField]
    private GameObject attackPanelGO;
    protected override void OverrideStart()
    {
        base.OverrideStart();
        GuestManager.Instance.OnGuestOffered += () => { isActive = false; };
        GuestManager.Instance.OnGuestExit += () => { progressValue = 0; };
        GuestManager.Instance.OnGuestEnter += ()=> { isActive = true; };
        attackPanelGO.SetActive(false);
        guestAngryCanvas.sortingOrder = 0;
    }
    protected override void OverrideUpdate()
    {
        if (isActive)
        {
            DefineAddValue(ref progressValue, progressMaxValue, addValue * Time.deltaTime);
        }

        if(CheckFull() && !isRunCor)
        {
            isRunCor = true;
            print("고객 화남");
            Timing.RunCoroutine(AngryProcess());
        }
    }
    private IEnumerator<float> AngryProcess()
    {
        //상태 복구
        GuestManager.Instance.isGuestAngry = true;
        guestAngryCanvas.sortingOrder = 6;

        attackPanelGO.SetActive(true);
        float num = 0;
        while (num < 2)
        {
            if(GuestManager.Instance.isGuestAngry == false)
            {
                print("완만한 해결");
                isActive = false;
                progressValue = 0;
                break;
            }
            yield return Timing.WaitForOneFrame;
            num += Time.deltaTime;
        }

        if (GuestManager.Instance.isGuestAngry == true)
        {
            print("공격 받음");
        }
        attackPanelGO.SetActive(false);
        isRunCor = false;
        guestAngryCanvas.sortingOrder = 0;
    }
}
