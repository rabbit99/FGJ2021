using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FGJ2021_LinXhan
{
    public class DialogueSystem : IGameSystem
    {
        private int m_San;
        private ProjectResources m_Resources; //TODO:頭像跟名字的導入
        private TextAsset m_InkAsset = null;
        private Ink.Runtime.Story m_Story; //TODO:以防萬一，我暫時先加一下Ink的Story的namespace，我怕災難出現

        private Action<string> m_SetName = null;
        private Action<string> m_SetSentence = null;
        private Action<Sprite> m_SetAvatar = null;
        private Action m_SetChoicePanel = null;

        private string m_TmpName = "";
        private string m_TmpSentence = "";
        private string m_CheckState = "";
        private bool m_StoryEnd = false;
        private bool m_IsFinalDay = false;
        private Dictionary<int, Action> m_ChoiceActionBtns = null;
        private Dictionary<int, string> m_BtnTexts = null;
        private Sprite m_Avatar = null;
        private string m_SaveCurrectStory;
        private int m_EvilNum;

        public override void Initialize()
        {
            m_StoryEnd = false;
            m_TmpName = "";
            m_TmpSentence = "";
            m_DelegateInitialize();
            m_Story = new Ink.Runtime.Story(m_InkAsset.text);
            if(m_Resources.GetCurrectStory().Equals(""))
            {

            }
            else
            {
                m_Story.state.LoadJson(m_Resources.GetCurrectStory());
                m_Resources.SaveCurrectStory("");
            }
            StoryContinue();
        }

        public override void Update()
        {
            m_DelegateGameSystemUpdate();
        }

        public void SaveStory()
        {
            m_Story.state.ToJson();
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

        public void SetResources(ProjectResources projectResources)
        {
            m_Resources = projectResources;
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
                CheckState();
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
                //CheckState();
                StoryEnd();
            }

        }

        public void SplitSentenceAndSetSentenceandName(string sentence)
        {
            if (sentence.Contains(":"))//TODO:全形跟半行的問題
            {

                string[] data = sentence.Split(':');
                m_TmpName = data[0];
                m_TmpSentence = data[1];
                if (m_TmpName.Equals("Player"))
                {
                    //TODO:Avatar
                    //m_Avatar = m_AvatarLocal.LoadAsset();
                    m_SetName(m_TmpName);
                }
                else
                {
                    m_SetName(m_TmpName);
                    //TODO:m_SetAvatar(m_Avatar);
                }

                if(m_TmpSentence.Contains("&"))
                {
                    string[] sentenceData = m_TmpSentence.Split('&');
                    m_TmpSentence = sentenceData[0];
                    m_CheckState = sentenceData[1];
                    Debug.Log(m_CheckState);

                }

                m_SetSentence(m_TmpSentence);
            }
            else
            {
                m_TmpName = "";
                m_TmpSentence = sentence;
                if (m_TmpSentence.Contains("&"))
                {
                    string[] sentenceData = m_TmpSentence.Split('&');
                    m_TmpSentence = sentenceData[0];
                    m_CheckState = sentenceData[1];
                }

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
            if (m_Resources.IsFinalDay())
            {
                //TODO:做最終結局的生成與判斷
                Debug.Log("FinalDay");
            }


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

        private void CheckState()
        {
            if(m_CheckState.Contains("CHECKMINIGAME"))
            {
                m_CheckState = "";
                string day = m_Resources.GetDays();
                day = day.Replace("Day", "");
                Debug.Log(day);
                int num = int.Parse(day) - 1;
                int check = m_Resources.GetCurrectCheck();
                Debug.Log(num);
                Debug.Log(check);
                string[][] dayCheck = m_Resources.GetDayNeedCheck();
                string[][] dayBeCheck = m_Resources.GetDayBeCheck();
                var checkList = m_Story.variablesState[dayCheck[num][check]] as Ink.Runtime.InkList;
                if(checkList.Equals(dayBeCheck))
                {

                }
                else
                {
                    m_SaveCurrectStory = m_Story.state.ToJson();
                    m_Resources.SaveEvilNum(m_EvilNum);
                    m_Resources.SaveConveration();
                    m_Resources.SaveCurrectCheck();
                    m_Resources.SaveCurrectStory(m_SaveCurrectStory);
                    m_Resources.SavePlayerPref();
                    SceneManager.LoadScene("Run"); //TODO:跑步視窗切換
                }


            }
            if(m_CheckState.Contains("ADDEVILNUM"))
            {
                m_CheckState = "";
                m_EvilNum += 1;
                m_Resources.SaveEvilNum(m_EvilNum);
                Debug.Log("ADDEVILNUM");
            }
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

