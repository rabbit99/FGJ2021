using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SanData", menuName = "Item/San Data", order = 1)]
public class SanData : GameData
{
    public float san;
    public float san_limit;

    public bool IsOver()
    {
        return san >= san_limit;
    }
}
