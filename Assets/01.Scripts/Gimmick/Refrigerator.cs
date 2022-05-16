using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : SlidingObject
{
    public Transform container;

    public Transform[] itemSpawnTrms;

    [SerializeField]
    private GameObject chickenPrefab;
    protected override void Start()
    {
        base.Start();
        DayManager.Instance.OnPurchaseChicken += CallOnPurchaseChicken;
        for (int i = 0; i < 5; i++)
        {
            AddItemToRefrigerator();
        }
    }
    private void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.O))
        {
            AddItemToRefrigerator();
            
        }*/
        if(Input.GetKeyDown(KeyCode.Tab)&& !Input.GetKeyDown(KeyCode.Space))
        {
            activeButton.onClick?.Invoke();
        }
    }
    public void CallOnPurchaseChicken()
    {
        if (SaveManager.Instance.moneyData.SubGold(5))
        {
            AddItemToRefrigerator();
        }
    }
    public void AddItemToRefrigerator()
    {
        Transform chickenSpawnTrm = itemSpawnTrms[Random.Range(0, itemSpawnTrms.Length)];
        GameObject chickenObj = Instantiate(chickenPrefab, container);
        chickenObj.transform.position = chickenSpawnTrm.position;
        ChickenData chickenData = chickenObj.GetComponent<ChickenData>();
        chickenData.SetUp(ChickenType.RAW);
        GameManager.Instance.makedChickenList.Add(chickenData);
    }

}
