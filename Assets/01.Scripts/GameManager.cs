using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private SliderGimmick slider;
    [SerializeField]
    private RectTransform smartPhone;
    [field: SerializeField]
    public bool isSmartPhoneUse { get; private set; } = false;

    [SerializeField]
    private Transform chickenSpawnTrm;
    [SerializeField]
    private GameObject chickenPrefab;

    [SerializeField]
    private Image angryPanel;

    public bool isAngry;

    public int Difficulty = 0;
    public int MaxDifficulty = 3;

    public CinemachineImpulseSource ImpulseSource;

    public List<ChickenData> makedChickenList = new List<ChickenData>();
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (!isAngry)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (slider.Action())
                {
                    GameObject chickenObj = Instantiate(chickenPrefab, chickenSpawnTrm);
                    chickenObj.transform.position = chickenSpawnTrm.position;
                    ChickenData chickenData = chickenObj.GetComponent<ChickenData>();
                    chickenData.SetUp(ChickenType.RAW);
                    makedChickenList.Add(chickenData);
                    slider.progressValue = 0;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSmartPhoneUse = !isSmartPhoneUse;
            if (isSmartPhoneUse)
            {
                smartPhone.DOAnchorPosY(0, .25f);
            }
            else
            {
                smartPhone.DOAnchorPosY(-860, .25f);

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            print("발사");
            GuestManager.Instance.ShootGuest();
        }

        if (isAngry)
        {
            angryPanel.color = new Color(1, 0, 0, .25f);
        }
        else
        {
            angryPanel.color = new Color(0, 0, 0, 0);
        }

    }
    public void CameraShaking(float force)//주어진 값으로 카메라 흔드는 함수
    {
        ImpulseSource.GenerateImpulse(force);
    }

    public void AddDifficulty()
    {
        if (Difficulty < MaxDifficulty)
            Difficulty++;
    }

    public void SubDifficulty()
    {
        if (Difficulty > 1)
            Difficulty--;
    }

    public void SetDifficulty(int InNum)
    {
        if (InNum < MaxDifficulty && InNum > 1)
            Difficulty = InNum;
    }
}
