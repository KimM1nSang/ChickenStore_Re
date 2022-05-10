using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SlidingObject : MonoBehaviour
{
    public Button activeButton;
    private RectTransform rt;

    [SerializeField]
    private float activeSpeed = .5f;
    [SerializeField]
    private bool isActive = false;

    public Vector2 activePos;
    public Vector2 unActivePos;

    private void Start()
    {
        rt = GetComponent<RectTransform>();

        activeButton.onClick.AddListener(()=> {
            if(isActive)
            {
                rt.DOAnchorPos(unActivePos, activeSpeed);
            }
            else
            {
                rt.DOAnchorPos(activePos, activeSpeed);
            }
            isActive = !isActive;
        });
    }
}
