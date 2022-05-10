using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    // ex) 천만분의 1
    public static bool GetThisChanceResult(float Chance)
    {
        if (Chance < 0.0000001f)
        {
            Chance = 0.0000001f;
        }

        bool Success = false;
        int RandAccuracy = 10000000;
        float RandHitRange = Chance * RandAccuracy;
        int Rand = UnityEngine.Random.Range(1, RandAccuracy + 1);
        if (Rand <= RandHitRange)
        {
            Success = true;
        }
        return Success;
    }

    // 백분률
    public static bool GetThisChanceResult_Percentage(float Percentage_Chance)
    {
        if (Percentage_Chance < 0.0000001f)
        {
            Percentage_Chance = 0.0000001f;
        }

        Percentage_Chance = Percentage_Chance / 100;

        bool Success = false;
        int RandAccuracy = 10000000;
        float RandHitRange = Percentage_Chance * RandAccuracy;
        int Rand = UnityEngine.Random.Range(1, RandAccuracy + 1);
        if (Rand <= RandHitRange)
        {
            Success = true;
        }
        return Success;
    }

    public static bool DefineAddValue(ref float currentValue, float maxValue, float amount)
    {
        if (currentValue < maxValue)
        {
            if (currentValue <= maxValue - amount)
            {
                currentValue += amount;
            }
            else
            {
                currentValue += maxValue - currentValue;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool DefineSubValue(ref float currentValue, float amount)
    {
        if (currentValue > 0)
        {
            if (currentValue >= amount)
            {
                currentValue -= amount;
            }
            else
            {
                currentValue -= currentValue;
            }
            return true;
        }
        else
        {
            return false;
        }

    }
}
