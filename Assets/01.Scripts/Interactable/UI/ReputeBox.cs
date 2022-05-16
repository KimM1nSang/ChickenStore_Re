using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputeBox : MonoBehaviour
{
    [SerializeField]
    private Text reputeText;
    private void Start()
    {
        SaveManager.Instance.moneyData.OnChangeRepute += CallOnChangeRepute;
    }

    public void CallOnChangeRepute()
    {
        reputeText.text = string.Format("{0} Á¡", SaveManager.Instance.moneyData.Repute);
    }
}
