using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : SlidingObject
{
    public Transform container;

    public Transform[] itemSpawnTrms;

    [SerializeField]
    private GameObject chickenPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            AddItemToRefrigerator();
            
        }
        if(Input.GetKeyDown(KeyCode.Tab)&& !Input.GetKeyDown(KeyCode.Space))
        {
            activeButton.onClick?.Invoke();
        }
    }

    public void AddItemToRefrigerator()
    {
        if(GameManager.Instance.makedChickenList.Count < 3)
        {
            Transform chickenSpawnTrm = itemSpawnTrms[Random.Range(0, itemSpawnTrms.Length)];
            GameObject chickenObj = Instantiate(chickenPrefab, container);
            chickenObj.transform.position = chickenSpawnTrm.position;
            ChickenData chickenData = chickenObj.GetComponent<ChickenData>();
            chickenData.SetUp(ChickenType.RAW);
            GameManager.Instance.makedChickenList.Add(chickenData);
        }
    }

}
