using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FGJ2021_LinXhan
{
    public static class UITool
    {
        private static GameObject m_CanvasObj = null;

        public static GameObject FindUIGameObject(string UIName)
        {
            if (m_CanvasObj == null)
            {
                m_CanvasObj = UnityTool.FindGameObject("Canvas");
            }
            if (m_CanvasObj == null)
            {
                return null;
            }
            return UnityTool.FindChildGameObject(m_CanvasObj, UIName);
        }

        public static T GetUIComponent<T>(GameObject container, string uiName)
        where T : UnityEngine.Component
        {
            GameObject ChildGameObject = UnityTool.FindChildGameObject(container, uiName);
            UnityTool.FindChildGameObject(container, uiName);
            if(ChildGameObject == null)
            {
                return null;
            }
            T tempObj = ChildGameObject.GetComponent<T>();
            if(tempObj == null)
            {
                Debug.LogWarning("元件["+uiName+"]不是["+typeof(T)+"]");
            }
            return tempObj;
        }
    }
}

