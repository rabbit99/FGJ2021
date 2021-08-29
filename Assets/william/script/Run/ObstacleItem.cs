using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItem : CollectionItem
{
    public delegate void OnHit();
    public OnHit onHit;


    public override void Hit(string name)
    {
        base.Hit(name);
        switch (name)
        {
            case "Player":
                onHit();
                break;
            case "GirlFriend":
                break;
        }
    }
}
