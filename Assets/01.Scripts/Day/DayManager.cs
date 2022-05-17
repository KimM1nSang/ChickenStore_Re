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
    // 3�� 30�� == �ϰ� �ð�
    public GameObject NextDayPanel;
    public float curDay = 0;
    public bool canGotoNextDay = false;

    public Button gotoNextDayBtn;
    public Button purchaseChickenBtn;
    public Button stopBtn;

    public Action OnChangeDay;
    public Action OnPurchaseChicken;

    private bool gotoNextDay = false;

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
        stopBtn.onClick.AddListener(()=> {
            if(GuestManager.Instance.curGuest.isArrive && GuestManager.Instance.curGuest.canOffered)
            {
                gotoNextDay = true;
            }
        });
        purchaseChickenBtn.onClick.AddListener(() => { OnPurchaseChicken?.Invoke(); });
        SaveManager.Instance.moneyData.OnChangeGold += 
            () => { MoneyText.text = $"���� �ڻ� : {SaveManager.Instance.moneyData.Gold} , ���� ġŲ : {GameManager.Instance.makedChickenList.Count}" ; };
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

            stopBtn.gameObject.SetActive(GameManager.Instance.makedChickenList.Count < 1);

            if (curTime.Day != lastDay || gotoNextDay)
            {
                gotoNextDay = false;
                stopBtn.gameObject.SetActive(false);
                curTime = new DateTime(curTime.Year,curTime.Month,curTime.Day);
                GuestManager.Instance.curGuest.SetExitComment("");
                GuestManager.Instance.Complete(()=> {
                 NextDayPanel.SetActive(true);

                GameManager.Instance.isPlayerAngry = true;

                curDay++;
                // ��¥�� �����鼭 �Ͼ�� �ϵ�
                if(curDay % 5 == 0 && curDay < 24)
                {
                    GameManager.Instance.AddDifficulty();
                }
                string infoStr = "";
                switch (GameManager.Instance.Difficulty)
                {
                    case 0:
                        infoStr = "�մԵ��� ������ �䱸�ϱ� �����ߴ�.\n���콺 �巡�� & ������� ġŲ�� ������ �մԿ��� ��������.\nȭ�� ������ ��ư�� �����ų� Tab �� ���� ����� �� ���ִ�. \nSpace �� ���� ��Ʈ������ �ؼ� �ؾ� �Ѵ�. ��Ʈ������ �������� �ൿ���� �� �� ����.";
                        break;
                    case 1:
                        infoStr = "�մԵ��� �����̵� ġŲ�� �䱸�ϱ� �����ߴ�.\n Q �� ���� �⸧ �µ��� �ø� �� �ִ�. \n �⸧ �µ� �����̵尡 �Ͼ�� �϶� ���̺� ������ ��� �ڽ��� �巡�� & ����ϰ� 2�� ���� ��ٷ��� �Ѵ�.";
                        break;
                    case 2:
                        infoStr = "�մԵ��� ��� ġŲ�� �䱸�ϱ� �����ߴ�.\n ���̺� ������ ���� �ڽ��� �巡�� & ��� �ϸ� ����� �״�� ������ �ҽ��� �߶�����.";
                        break;
                    case 3:
                        infoStr = "�մԵ��� �γ����� ����������. �մ��� �γ����� ���������� �����Ѵ�. \n ��Ŭ������ �մ��� óġ �� �� �ִ�.";
                        break;
                    case 4:
                        infoStr = "�մԵ��� �Ѹ�Ŭ�� �䱸�ϱ� �����ߴ�.\n ���̺� ������ ��ư�� ���� ������, �巡�� & ��� �ϸ� ����� �״�� ������ �Ѹ�Ŭ�� �߶�����.";
                        break;
                }
                infoText.text = infoStr;
                }
                ,true);
               

                while (!canGotoNextDay)
                {
                    yield return Timing.WaitForOneFrame;
                }
                OnChangeDay?.Invoke();

                canGotoNextDay = false;
                GameManager.Instance.isPlayerAngry = false;

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
