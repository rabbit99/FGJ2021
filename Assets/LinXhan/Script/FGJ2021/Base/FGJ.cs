﻿using System.Collections;
using UnityEngine;

namespace FGJ2021
{
    public partial class FGJ : MonoBehaviour
    {
        private DialogueSystem m_DialogueSystem = null;
        //TODO:private GameEventSystem m_GameEventSystem = null;
        private ProjectResources m_Resources = null;

        // Use this for initialization
        void Start()
        {
            m_DialogueSystem = new DialogueSystem();
            m_Resources = new ProjectResources();
            GetDialgoueUI();
            Debug.Log(m_DialogueUI);
            m_Resources.Initialize();
            GetAndInitinalDialogueUI();
            SetDialgoueSystemDelegateInitialize();
            SetDialogueSystemDelegateUpdate();
            Debug.Log(m_Resources.GetDays());
            m_Resources.NextDays();
            Debug.Log(m_Resources.GetDays());
        }

        // Update is called once per frame
        void Update()
        {
            m_DialogueSystem.Update();
        }
    }
}