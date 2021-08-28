using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTool
{
    public static GameObject FindGameObject(string gameObjectName)
    {
        GameObject pTmpGameObj = GameObject.Find(gameObjectName);
        if(pTmpGameObj == null)
        {
            Debug.LogWarning("場景中找不到GameObject[" + gameObjectName + "]物件");
            return null;
        }
        return pTmpGameObj;
    }

    public static GameObject FindChildGameObject(GameObject container, string gameObjectName)
    {
        if(container == null)
        {
            Debug.LogError("NGUICustomTools.GetChild:Container = null");
            return null;
        }

        Transform pGameObjectTF = null;

        if(container.name == gameObjectName)
        {
            pGameObjectTF = container.transform;
        }
        else
        {
            Transform[] allChildren = container.transform.GetComponentsInChildren<Transform>();


            foreach (Transform child in allChildren)
            {
                if(child.name == gameObjectName)
                {
                    if(pGameObjectTF == null)
                    {
                        pGameObjectTF = child;
                    }
                    else
                    {
                        Debug.LogWarning("Container["+container.name+"]找出重複物件名稱["+gameObjectName+"]");
                    }
                }
            }
         

        }
        if(pGameObjectTF == null)
        {
            Debug.LogError("物件[" + container.name + "]找不到子原件[" + gameObjectName + "]");
            return null;
        }
        return pGameObjectTF.gameObject;

    }
}
