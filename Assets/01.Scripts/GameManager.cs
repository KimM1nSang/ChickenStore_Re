using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private SliderGimmick slider;
    [SerializeField]
    private RectTransform smartPhone;
    [field:SerializeField]
    public bool isSmartPhoneUse { get; private set; } = false;

    [SerializeField]
    private Transform chickenSpawnTrm;
    [SerializeField]
    private GameObject chickenPrefab;

    [SerializeField]
    private Image angryPanel;

    public bool isAngry;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if(!isAngry)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (slider.Action())
                {
                    Instantiate(chickenPrefab, chickenSpawnTrm).transform.position = chickenSpawnTrm.position;
                    slider.progressValue = 0;
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSmartPhoneUse = !isSmartPhoneUse;
            if (isSmartPhoneUse)
            {
                smartPhone.DOAnchorPosY(0,.25f);
            }
            else
            {
                smartPhone.DOAnchorPosY(-860, .25f);

            }
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

}
