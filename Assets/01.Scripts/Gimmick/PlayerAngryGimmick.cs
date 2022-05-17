using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerAngryGimmick : SlidingObject
{
    [SerializeField]
    private RectTransform smartPhone;

    [SerializeField]
    private Canvas playerAngryCanvas;
    [SerializeField]
    private Image angryPanel;

    protected override void Start()
    {
        base.Start();
        playerAngryCanvas.sortingOrder = 2;
    }
    public override void ActiveSliding()
    {
        GameManager.Instance.isSmartPhoneUse = !GameManager.Instance.isSmartPhoneUse;
        if (isActive)
        {
            rt.DOAnchorPos(unActivePos, activeSpeed);
        }
        else
        {
            rt.DOAnchorPos(activePos, activeSpeed);
        }
        isActive = !isActive;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            act?.Invoke();
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
