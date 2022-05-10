using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBox : MonoBehaviour
{

    [SerializeField]
    private Text moneyText;
    private void Start()
    {
        SaveManager.Instance.moneyData.OnChangeGold += CallOnChangeGold;
    }

    public void CallOnChangeGold()
    {
        moneyText.text = string.Format("{0} $",SaveManager.Instance.moneyData.Gold);
    }
}
