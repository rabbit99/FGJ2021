using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FGJ2021
{
    public class DialogueSystem : IGameSystem
    {
        private IResources m_Resources; //TODO:頭像跟名字的導入
        private TextAsset m_InkAsset = null;
        private Ink.Runtime.Story m_Story; //TODO:以防萬一，我暫時先加一下Ink的Story的namespace，我怕災難出現

        private Action<string> m_SetName = null;
        private Action<string> m_SetSentence = null;
        private Action<Sprite> m_SetAvatar = null;
        private Action m_SetChoicePanel = null;

        private string m_TmpName = "";
        private string m_TmpSentence = "";
        private int m_San;
        private bool m_StoryEnd = false;
        private Dictionary<int, Action> m_ChoiceActionBtns = null;
        private Dictionary<int, string> m_BtnTexts = null;
        private Sprite m_Avatar = null;

        public override void Initialize()
        {
            m_StoryEnd = false;
            m_TmpName = "";
            m_TmpSentence = "";
            m_DelegateInitialize();
            m_Story = new Ink.Runtime.Story(m_InkAsset.text);
            StoryContinue();
        }



        public override void Update()
        {
            m_DelegateGameSystemUpdate();
        }

        public void GetName(Action<string> action)
        {
            m_SetName = action;
        }

        public void GetSentence(Action<string> action)
        {
            m_SetSentence = action;
        }

        public void GetAvatar(Action<Sprite> action)
        {
            m_SetAvatar = action;
        }

        public void GetChoicePanel(Action action)
        {
            m_SetChoicePanel = action;
        }

        public Dictionary<int, Action> GettChoiceActionBtns()
        {
            return m_ChoiceActionBtns;
        }

        public Dictionary<int, string> GetBtnText()
        {
            return m_BtnTexts;
        }

        public Sprite GetImage()
        {
            return m_Avatar;
        }

        public void StoryContinue()
        {

            if (m_Story.canContinue)
            {
                string sentence = m_Story.Continue();
                sentence.Trim();
                SplitSentenceAndSetSentenceandName(sentence);
            }
            else if (m_Story.currentChoices.Count > 0)
            {
                SetStoryChoice();
            }

            if (!m_Story.canContinue && m_Story.currentChoices.Count <= 0)
            {
                StoryEnd();
            }

        }

        public void SplitSentenceAndSetSentenceandName(string sentence)
        {
            if (sentence.Contains(":") || sentence.Contains("："))//TODO:全形跟半行的問題
            {

                string[] data = sentence.Split(':');
                m_TmpName = data[0];
                m_TmpSentence = data[1];
                if (m_TmpName.Equals("Player"))
                {
                    //TODO:characterName
                    //TODO:Avatar
                    //m_Avatar = m_AvatarLocal.LoadAsset();
                    //m_SetName(m_CharacterNameLocal.GetLocalizedString());

                }
                else
                {
                    //m_AvatarLocal.SetReference("Avatar", m_TmpName);
                    //m_Avatar = m_AvatarLocal.LoadAsset();
                    m_SetName(m_TmpName);
                    m_SetAvatar(m_Avatar);
                }

                m_SetSentence(m_TmpSentence);

            }
            else
            {
                m_TmpName = "";
                m_TmpSentence = sentence;
                m_SetName(m_TmpName);
                m_SetSentence(m_TmpSentence);

            }
        }


        public void SetStoryTextAsset(TextAsset storyTextAsset)
        {
            m_InkAsset = storyTextAsset;
        }

        private void SetStoryChoice()
        {
            Dictionary<int, Action> tmpActions = new Dictionary<int, Action>();
            Dictionary<int, string> tmpBtnText = new Dictionary<int, string>();
            //TODO:產生出比較不會出事情的Btn系統
            for (int buttonNum = 0; buttonNum < m_Story.currentChoices.Count; buttonNum++)
            {
                Choice choice = m_Story.currentChoices[buttonNum];
                tmpActions.Add(buttonNum, () => OnClickChoiceButton(choice));
                string choiceText = choice.text.Trim();
                tmpBtnText.Add(buttonNum, choiceText);


            }
            m_ChoiceActionBtns = tmpActions;
            m_BtnTexts = tmpBtnText;
            m_SetChoicePanel();
        }

        private void OnClickChoiceButton(Choice choice)
        {
            m_Story.ChooseChoiceIndex(choice.index);
            StoryContinue();
        }

        private void StoryEnd()
        {
            m_StoryEnd = true;
        }

        public bool IsStoryEnd()
        {
            return m_StoryEnd;
        }

    }
}

