using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FGJ2021_LinXhan
{
    public class DialogueUI : IUserInterface
    {
        [SerializeField] private GameObject m_SentencePanel;
        [SerializeField] private Text m_CharacterName;
        [SerializeField] private Text m_Sentence;
        [SerializeField] private Image m_Avatar;
        [SerializeField] private Button m_ContinueButton;

        [SerializeField] private GameObject m_ChoicePanel;
        [SerializeField] private Button m_ButtonA;
        [SerializeField] private Button m_ButtonB;
        [SerializeField] private Button m_ButtonC;
        [SerializeField] private Button m_ButtonD;

        private Dictionary<int, Action> m_ChoiceActionBtns;
        private Dictionary<int, string> m_BtnTexts;

        private Action m_GetContinueStory;
        private Func<Dictionary<int, Action>> m_GetChoiceActionBtns;
        private Func<Dictionary<int, string>> m_GetBtnTexts;

        public override void Initialize()
        {
            ShowSentencePanel();
            HideChoicePanel();
            SetContinueBtn();
            m_DelegateInitialize();
        }

        public override void UIUpdate()
        {
            base.UIUpdate();
        }

        public override void Release()
        {
            base.Release();
        }

        public void GetChoiceActionBtns(Func<Dictionary<int, Action>> func)
        {
            m_GetChoiceActionBtns = func;
        }

        public void SetChoiceActionBtns(Dictionary<int, Action> choiceActionBtns)
        {
            m_ChoiceActionBtns = choiceActionBtns;
        }

        public void GetBtnTexts(Func<Dictionary<int, string>> func)
        {
            m_GetBtnTexts = func;
        }

        public void SetBtnTexts(Dictionary<int, string> btnTexts)
        {
            m_BtnTexts = btnTexts;
        }

        public void ShowChoicesAndHideSentences()
        {
            ShowChoicePanel();
            HideSentencePanel();
        }

        public void ShowSentencesAndHideChoices()
        {
            ShowSentencePanel();
            HideChoicePanel();
        }

        #region Sentence
        public void ShowSentencePanel()
        {
            m_SentencePanel.SetActive(true);
        }

        public void HideSentencePanel()
        {
            m_SentencePanel.SetActive(false);
        }

        public void SetNameText(string name)
        {
            this.m_CharacterName.text = name;
        }

        public void SetSentenceText(string sentence)
        {
            this.m_Sentence.text = sentence;
        }

        public void SetAvatar1(Sprite avatar)
        {
            this.m_Avatar.sprite = avatar;
        }

        public void SetContinueStory(Action action)
        {
            m_GetContinueStory = action;
        }

        public void SetContinueBtn()
        {
            m_ContinueButton.onClick.AddListener(() => m_GetContinueStory());
        }

        #endregion

        #region Choice
        public void ShowChoices()
        {
            m_ChoicePanel.SetActive(true);
        }

        public void HideChoices()
        {
            m_ChoicePanel.SetActive(false);
        }

        public void ShowChoicePanel()
        {
            m_ChoicePanel.SetActive(true);
        }

        public void HideChoicePanel()
        {
            m_ChoicePanel.SetActive(false);
        }

        public void SetAllBtnHiding()
        {
            HideButtonA();
            HideButtonB();
            HideButtonC();
            HideButtonD();
        }

        public void ShowButtonA()
        {
            m_ButtonA.gameObject.SetActive(true);
        }

        public void HideButtonA()
        {
            m_ButtonA.gameObject.SetActive(false);
        }

        public void ShowButtonB()
        {
            m_ButtonB.gameObject.SetActive(true);
        }

        public void HideButtonB()
        {
            m_ButtonB.gameObject.SetActive(false);
        }

        public void ShowButtonC()
        {
            m_ButtonC.gameObject.SetActive(true);
        }

        public void HideButtonC()
        {
            m_ButtonC.gameObject.SetActive(false);
        }

        public void ShowButtonD()
        {
            m_ButtonD.gameObject.SetActive(true);
        }

        public void HideButtonD()
        {
            m_ButtonD.gameObject.SetActive(false);
        }

        public void SetBtnAddListener(Action OnClickChoiceBtn) //TODO:Delegate要設定的東西，之後要調整
        {
            OnClickChoiceBtn();
            ShowSentencesAndHideChoices();
        }

        public void SetAllBtnState()
        {
            RefreshView();
            HideSentencePanel();
            ShowChoicePanel();
            m_ChoiceActionBtns = m_GetChoiceActionBtns();
            m_BtnTexts = m_GetBtnTexts();
            for (int i = 0; i < m_ChoiceActionBtns.Count; i++)
            {
                switch (i) //TODO:未來研究抽象工廠的寫法
                {
                    case 0:

                        m_ButtonA.GetComponentInChildren<Text>().text = m_BtnTexts[0];
                        m_ButtonA.onClick.AddListener(() => SetBtnAddListener(m_ChoiceActionBtns[0]));
                        ShowButtonA();
                        break;
                    case 1:
                        m_ButtonB.GetComponentInChildren<Text>().text = m_BtnTexts[1];
                        m_ButtonB.onClick.AddListener(() => SetBtnAddListener(m_ChoiceActionBtns[1]));
                        ShowButtonB();
                        break;
                    case 2:
                        m_ButtonC.GetComponentInChildren<Text>().text = m_BtnTexts[2];
                        m_ButtonC.onClick.AddListener(() => SetBtnAddListener(m_ChoiceActionBtns[2]));
                        ShowButtonC();
                        break;
                    case 3:
                        m_ButtonD.GetComponentInChildren<Text>().text = m_BtnTexts[3];
                        m_ButtonD.onClick.AddListener(() => SetBtnAddListener(m_ChoiceActionBtns[3]));
                        ShowButtonD();
                        break;
                    default:
                        Debug.Log("Something error happen in DialogueUI's button"); //TODO:要變成例外丟出
                        break;
                }
            }
        }

        private void RefreshView()
        {
            SetAllBtnHiding();

        }

        #endregion
    }
}