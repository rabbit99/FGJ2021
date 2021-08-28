using System.Collections;
using UnityEngine;

namespace FGJ2021
{
    public class SaveData
    {
        public int m_StartGame = 1;
        public int m_EvilNum = 0;
        public string m_CurrectStory = "";
        public int m_CurrectCheck = 0;
        public int m_Converation = 0;

        public void Initinal()
        {
                PlayerPrefs.SetInt("EvilNum", 0);
                PlayerPrefs.SetInt("Converation", 0);
                PlayerPrefs.SetString("CurrectStory", "");           
        }

        public void Save()
        {
            PlayerPrefs.SetInt("EvilNum", m_EvilNum);
            PlayerPrefs.SetInt("Converation", m_Converation);
            PlayerPrefs.SetString("CurrectStory", m_CurrectStory);
            PlayerPrefs.SetInt("StartGame", 0);
        }

        public void Load()
        {
            m_EvilNum = PlayerPrefs.GetInt("EvilNum");
            m_Converation = PlayerPrefs.GetInt("Converation");
            m_CurrectStory = PlayerPrefs.GetString("CurrectStory");
        }

    }
}