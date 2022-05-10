using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrieMachine : MonoBehaviour
{
    [field: SerializeField]
    public OilTempSlider oilTempSlider { get; private set; }

    public ChickenData curFriedChicken;
}
