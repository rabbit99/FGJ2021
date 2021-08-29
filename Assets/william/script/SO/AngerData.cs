using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AngerData", menuName = "Item/Anger Data", order = 1)]
public class AngerData : GameData
{
    public float anger;
    public float anger_max;
    public bool IsOver()
    {
        return anger <= 0;
    }

    public void Retset()
    {
        anger = anger_max;
    }
}
