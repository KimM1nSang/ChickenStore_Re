using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerAngryGimmick : MonoBehaviour
{
    [SerializeField]
    private RectTransform smartPhone;

    [SerializeField]
    private Canvas playerAngryCanvas;
    [SerializeField]
    private Image angryPanel;

    private void Start()
    {
        playerAngryCanvas.sortingOrder = 2;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.isSmartPhoneUse = !GameManager.Instance.isSmartPhoneUse;
            if (GameManager.Instance.isSmartPhoneUse)
            {
                smartPhone.DOAnchorPosY(0, .25f);
            }
            else
            {
                smartPhone.DOAnchorPosY(-860, .25f);

            }
        }

        if (GameManager.Instance.isPlayerAngry)
        {
            playerAngryCanvas.sortingOrder = 5;
            angryPanel.color = new Color(1, 0, 0, .25f);
        }
        else
        {
            playerAngryCanvas.sortingOrder = 2;
            angryPanel.color = new Color(0, 0, 0, 0);
        }
    }
}
