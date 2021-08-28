using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

public class UIController : MonoBehaviour
{

    public PlayMakerFSM fsm;


    public void ChangeSan(int San)
    {
        fsm = gameObject.GetComponent<PlayMakerFSM>();
        SetEventProperties.properties["san_now"] = San;
        fsm.SendEvent("CHANGE SAN");
    }

    public void ChangeAnger(int Anger)
    {
        fsm = gameObject.GetComponent<PlayMakerFSM>();
        SetEventProperties.properties["anger_now"] = Anger;
        fsm.SendEvent("CHANGE ANGER");
    }

    public void ChangeLife(int Life)
    {
        fsm = gameObject.GetComponent<PlayMakerFSM>();
        SetEventProperties.properties["life_now"] = Life;
        fsm.SendEvent("CHANGE LIFE");
    }




}
