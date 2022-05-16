using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using MEC;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    public Text[] dayText;
    public Text infoText;
    public Text MoneyText;
    public float timeMag = 1;
    // 3분 30초 == 일과 시간
    public GameObject NextDayPanel;
    public float curDay = 0;
    public bool canGotoNextDay = false;

    public Button gotoNextDayBtn;
    public Button purchaseChickenBtm;

    public Action OnChangeDay;
    public Action OnPurchaseChicken;

    [SerializeField]
    private string curTimeStr;
    private DateTime curTime; 
    public DateTime CurTime {
        get
        {
            return curTime;
        }
        private set
        {
            curTime = value;
            foreach (var item in dayText)
            {
                item.text = curTime.ToString("yy,MM,dd");
            }
        }
    }

    private void Awake()
    {
        Instance = this;
        CurTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
    }
    private void Start()
    {
        gotoNextDayBtn.onClick.AddListener(()=> { canGotoNextDay = true; });
        purchaseChickenBtm.onClick.AddListener(() => { OnPurchaseChicken?.Invoke(); });
        SaveManager.Instance.moneyData.OnChangeGold += 
            () => { MoneyText.text = $"보유 자산 : {SaveManager.Instance.moneyData.Gold}"; };
        NextDayPanel.SetActive(false);
        Timing.RunCoroutine(TimeManaging());
    }
    public IEnumerator<float> TimeManaging()
    {
        while (true)
        {
            curTimeStr = CurTime.ToString();
            yield return Timing.WaitForSeconds(60/(60* timeMag));
            float lastDay = curTime.Day;
            AddSecond(60);
            if(curTime.Day != lastDay)
            {
                GuestManager.Instance.Complete(()=> { },true);

                GameManager.Instance.isPlayerAngry = true;

                curDay++;
                NextDayPanel.SetActive(true);
                // 날짜가 지나면서 일어나는 일들
                if(curDay % 5 == 0 && curDay < 24)
                {
                    GameManager.Instance.AddDifficulty();
                }
                string infoStr = "";
                switch (GameManager.Instance.Difficulty)
                {
                    case 0:
                        infoStr = "손님들이 생닭을 요구하기 시작했다.\n 마우스 드래그 & 드랍으로 치킨을 움직여 손님에게 대접하자.\n 화면 좌측의 버튼을 누르거나 Tab 을 눌러 냉장고를 열 수있다. \n Space 를 눌러 스트레스를 해소 해야 한다. 스트래스가 가득차면 행동들을 할 수 없다.";
                        break;
                    case 1:
                        infoStr = "손님들이 프라이드 치킨을 요구하기 시작했다.\n Q 를 눌러 기름 온도를 올릴 수 있다. \n 기름 온도 슬라이드가 하얀색 일때 테이블 좌측의 노란 박스에 드래그 & 드랍하고 2초 정도 기다려야 한다.";
                        break;
                    case 2:
                        infoStr = "손님들이 양념 치킨을 요구하기 시작했다.\n 테이블 우측의 빨간 박스에 드래그 & 드랍 하면 모양은 그대로 이지만 소스가 발라진다.";
                        break;
                    case 3:
                        infoStr = "손님들의 인내심이 부족해졌다. 손님의 인내심이 부족해지면 공격한다. \n 우클릭으로 손님을 처치 할 수 있다.";
                        break;
                    case 4:
                        infoStr = "손님들이 뿌링클을 요구하기 시작했다.\n 테이블 우측의 버튼을 눌러 꺼낸후, 드래그 & 드랍 하면 모양은 그대로 이지만 뿌링클이 발라진다.";
                        break;
                }
                infoText.text = infoStr;

                while (!canGotoNextDay)
                {
                    yield return Timing.WaitForOneFrame;
                }
                OnChangeDay?.Invoke();

                canGotoNextDay = false;
                GameManager.Instance.   isPlayerAngry = false;

                NextDayPanel.SetActive(false);
                GuestManager.Instance.CreateGuest();
            }
        }
    }
    public void AddSecond(double inVal = 1)
    {
        CurTime = CurTime.AddSeconds(inVal);
    }
    public void AddDay(double inVal = 1)
    {
        CurTime = CurTime.AddDays(inVal);
        OnChangeDay?.Invoke();
    }

    public void SetDay(DateTime dateTime)
    {
        curTime = dateTime;
    }
}
