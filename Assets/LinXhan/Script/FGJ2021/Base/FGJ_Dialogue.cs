using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FGJ2021
{
    public partial class FGJ
    {
        DialogueUI m_DialogueUI;
        List<IUserInterface> m_UIs = new List<IUserInterface>();

        public void AddUI(IUserInterface ui)
        {
            m_UIs.Add(ui);
        }

        public void RemoveUI(IUserInterface ui)
        {
            if (m_UIs.Contains(ui))
            {
                m_UIs.Remove(ui);
            }
        }

        #region DialogueSystem
        public void SetDialgoueSystemDelegateInitialize()
        {
            m_DialogueSystem.m_DelegateInitialize = delegate ()
            {
                m_DialogueSystem.GetName(m_DialogueUI.SetNameText);
                m_DialogueSystem.GetSentence(m_DialogueUI.SetSentenceText);
                //m_DialogueSystem.GetAvatar(m_DialogueUI.SetAvatar);
                m_DialogueSystem.GetChoicePanel(m_DialogueUI.SetAllBtnState);
                m_DialogueSystem.SetStoryTextAsset(m_Resources.LoadTextAsset(m_Resources.GetDays())); //TODO:重點段落，設置存檔的點
                m_DialogueSystem.SetResources(m_Resources);
            };
            m_DialogueSystem.Initialize();
        }

        public void SetDialogueSystemDelegateUpdate()
        {
            m_DialogueSystem.m_DelegateGameSystemUpdate = delegate () //TODO:m_DelegateGameSystemUpdate會拋出意外NullReferenceException
            {
                if (m_UIs.Contains(m_DialogueUI)) //TODO:之後要改成陣列
                {
                    if (m_DialogueSystem.IsStoryEnd()) //TODO:IsStoryEnd的判斷要做在m_DialogueSystem裡面
                    {
                        m_Resources.NextDays();
                        m_Resources.SetCurrectCheck(0);
                        GetAndInitinalDialogueUI();
                        SetDialgoueSystemDelegateInitialize();
                        SetDialogueSystemDelegateUpdate();
                        Debug.Log(m_Resources.GetDays());
                        //RemoveUI(m_DialogueUI);
                        //m_DialogueUI.Release();
                        //SceneManager.LoadScene("Run");
                    }
                }

            };
        }
        #endregion

        #region DialogueUI
        public void SetDialogueUIDelegatInitialize()
        {
            m_DialogueUI.m_DelegateInitialize = delegate ()
            {
                m_DialogueUI.GetChoiceActionBtns(m_DialogueSystem.GettChoiceActionBtns);
                m_DialogueUI.GetBtnTexts(m_DialogueSystem.GetBtnText);
                m_DialogueUI.SetContinueStory(() => m_DialogueSystem.StoryContinue());
            };
            m_DialogueUI.Initialize();
        }

        private void GetDialgoueUI()
        {
            GameObject tmpDialogueUIObj = UITool.FindUIGameObject("DialogueUI");
            m_DialogueUI = tmpDialogueUIObj.GetComponent<DialogueUI>();
            AddUI(m_DialogueUI);
        }

        private void GetAndInitinalDialogueUI()
        {
            GetDialgoueUI();
            SetDialogueUIDelegatInitialize();
        }
        #endregion
    }
}