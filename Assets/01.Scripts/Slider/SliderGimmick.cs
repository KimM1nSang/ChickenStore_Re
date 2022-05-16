using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;
public class SliderGimmick : MonoBehaviour
{
    protected Slider slider;
    [SerializeField]
    public float progressValue;
    [SerializeField]
    public  float progressMaxValue = 100;
    [field:SerializeField]
    public virtual float SubSpeed { get; set; } = 1;
    [field:SerializeField]
    public virtual float addValue{ get; set; } = 1;

    public float valPercet;
    private void Start()
    {
        slider = GetComponent<Slider>();
        OverrideStart();
        DayManager.Instance.OnChangeDay += CallOnChangeDay;
    }
    private void Update()
    {
        RefreshSlider();
        OverrideUpdate();
    }
    public virtual void CallOnChangeDay()
    {
        progressValue = 0;
    }
    protected virtual void OverrideStart()
    {

    }
    protected virtual void OverrideUpdate()
    {

            DefineSubValue(ref progressValue, SubSpeed * Time.deltaTime);

    }
    public virtual bool Action()
    {
        if (GameManager.Instance.isSmartPhoneUse) return false;
        RefreshSlider();
        DefineAddValue(ref progressValue, progressMaxValue, addValue);
        return CheckFull();
    }
    public bool CheckFull()
    {
        return progressMaxValue == progressValue;
    }
    public bool CheckEmpty()
    {
        return progressValue == 0;
    }
    public void RefreshSlider()
    {
        valPercet = (progressValue / progressMaxValue) * 100;
        slider.value = (progressValue / progressMaxValue);
    }
}
