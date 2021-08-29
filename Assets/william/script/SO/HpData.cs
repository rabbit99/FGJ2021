using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HpData", menuName = "Item/Hp Data", order = 1)]
public class HpData : GameData
{
    public float hp;
    public float hp_max;
    public bool IsOver()
    {
        return hp <= 0;
    }

    public void Retset()
    {
        hp = hp_max;
    }
}
