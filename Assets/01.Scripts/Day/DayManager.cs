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
            () => { MoneyText.text = $"���� �ڻ� : {SaveManager.Instance.moneyData.Gold}"; };
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
                // ��¥�� �����鼭 �Ͼ�� �ϵ�
                if(curDay % 5 == 0 && curDay < 24)
                {
                    GameManager.Instance.AddDifficulty();
                }
                string infoStr = "";
                switch (GameManager.Instance.Difficulty)
                {
                    case 0:
                        infoStr = "�մԵ��� ������ �䱸�ϱ� �����ߴ�.\n ���콺 �巡�� & ������� ġŲ�� ������ �մԿ��� ��������.\n ȭ�� ������ ��ư�� �����ų� Tab �� ���� ����� �� ���ִ�. \n Space �� ���� ��Ʈ������ �ؼ� �ؾ� �Ѵ�. ��Ʈ������ �������� �ൿ���� �� �� ����.";
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
