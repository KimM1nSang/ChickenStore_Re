using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MoneyData : ISerializeble
{
    [Tooltip("Çö±Ý")]
    [SerializeField] private float gold;

    public float Gold
    {
        get { return gold; }
    }

    public Action OnChangeGold;

    public void AddGold(float amount)
    {
        gold += amount;
        OnChangeGold?.Invoke();
    }
    public void Desirialize(string jsonString)
    {
        JsonUtility.FromJsonOverwrite(jsonString, this);
    }

    public string GetJsonKey()
    {
        return "MoneyData";
    }

    public JObject Serialize()
    {
        string jsonString = JsonUtility.ToJson(this);
        Debug.Log(jsonString);
        JObject returnVal = JObject.Parse(jsonString);

        return returnVal;
    }
}
