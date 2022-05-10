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
    private Image angryPanel;
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
            angryPanel.color = new Color(1, 0, 0, .25f);
        }
        else
        {
            angryPanel.color = new Color(0, 0, 0, 0);
        }
    }
}
