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
            Debug.LogWarning("�������䤣��GameObject[" + gameObjectName + "]����");
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
                        Debug.LogWarning("Container["+container.name+"]��X���ƪ���W��["+gameObjectName+"]");
                    }
                }
            }
         

        }
        if(pGameObjectTF == null)
        {
            Debug.LogError("����[" + container.name + "]�䤣��l���[" + gameObjectName + "]");
            return null;
        }
        return pGameObjectTF.gameObject;

    }
}
