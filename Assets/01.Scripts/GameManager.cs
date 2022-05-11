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



    public bool isPlayerAngry = false;
    private int difficulty = 0;
    public int Difficulty
    {
        get
        {
            return difficulty;
        }
        set
        {
            difficulty = value;

            GameChangeAsDifficulty();
        }
    }
    public int MaxDifficulty = 3;

    public CinemachineImpulseSource ImpulseSource;

    public List<ChickenData> makedChickenList = new List<ChickenData>();

    [Header("��͵�")]
    [SerializeField] [Tooltip("�γ���")]
    private GameObject Patience;
    [SerializeField] [Tooltip("��")]
    private GameObject BulletBox;
    [SerializeField] [Tooltip("Ƣ���")]
    private GameObject FrieMachine;
    [SerializeField] [Tooltip("�����")]
    private GameObject Refrigerator;
    [SerializeField] [Tooltip("�÷��̾� �г�")]
    private GameObject PlayerAngryGimmick;
    private void Awake()
    {
        Instance = this;
    }
    public void GameChangeAsDifficulty()
    {
        switch (Difficulty)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
    public void CameraShaking(float force)//�־��� ������ ī�޶� ���� �Լ�
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
