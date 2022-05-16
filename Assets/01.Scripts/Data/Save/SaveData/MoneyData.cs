using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MoneyData : ISerializeble
{
    [Tooltip("현금")]
    [SerializeField] private float gold;

    public float Gold
    {
        get { return gold; }
    }
    
    [Tooltip("평판")]
    [SerializeField] private float repute;

    public float Repute
    {
        get { return repute; }
    }

    public Action OnChangeGold;
    public Action OnChangeRepute;

    public void AddGold(float amount)
    {
        gold += amount;
        OnChangeGold?.Invoke();
    }

    public bool SubGold(int v)
    {
        if (gold >= v)
        {
            gold -= v;
            OnChangeGold?.Invoke();
            return true;
        }
        return false;
    }
    public void AddRepute(float amount)
    {
        repute += amount;
        OnChangeRepute?.Invoke();
    }

    public void SubRepute(int v)
    {
        repute -= v;
        OnChangeRepute?.Invoke();
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
