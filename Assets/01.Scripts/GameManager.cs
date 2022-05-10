using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField]
    public bool isSmartPhoneUse { get; set; } = false;

    [SerializeField]
    private Transform chickenSpawnTrm;
    [SerializeField]
    private GameObject chickenPrefab;


    public bool isPlayerAngry = false;

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
       /* if (!isPlayerAngry)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (oilTempSlider.Action())
                {
                    GameObject chickenObj = Instantiate(chickenPrefab, chickenSpawnTrm);
                    chickenObj.transform.position = chickenSpawnTrm.position;
                    ChickenData chickenData = chickenObj.GetComponent<ChickenData>();
                    chickenData.SetUp(ChickenType.RAW);
                    makedChickenList.Add(chickenData);
                    oilTempSlider.progressValue = 0;
                }
            }

        }*/
     
      

        

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
