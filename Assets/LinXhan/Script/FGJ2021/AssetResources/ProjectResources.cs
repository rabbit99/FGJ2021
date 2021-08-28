using System.Collections;
using UnityEngine;

namespace FGJ2021
{
    public class ProjectResources :IResources
    {
        private const string UIPath = "UI/";
        private const string SpritePath = "Sprites/";
        private const string InkStoryPath = "InkStory/";
        Converation m_Converation = null;
        SaveData m_SaveData = null;
        public void Initialize()
        {
            m_Converation = new Converation();
            m_SaveData = new SaveData();
            m_Converation.Initialize();
        }

        public override Sprite LoadCharacterAvatar(string CharacterAvatarName)
        {
            Sprite res = Resources.Load<Sprite>(SpritePath + CharacterAvatarName);

            if (res == null)
            {
                Debug.Log("無法載入路徑" + SpritePath + CharacterAvatarName);
                return null;
            }
            return res;
        }

        public override Sprite LoadSprite(string SpriteName)
        {
            Sprite res = Resources.Load<Sprite>(SpritePath + SpriteName);

            if (res == null)
            {
                Debug.Log("無法載入路徑" + SpritePath + SpriteName);
                return null;
            }
            return res;
        }

        public override GameObject LoadUI(string UIName)
        {
            UnityEngine.Object res = LoadGameObjectFromResourcePath(UIPath + UIName);
            if (res == null)
                return null;
            return res as GameObject;
        }

        public UnityEngine.Object LoadGameObjectFromResourcePath(string AssetPath)
        {
            UnityEngine.Object res = Resources.Load(AssetPath);
            if (res == null)
            {
                Debug.LogWarning("無法載入路徑[" + AssetPath + "]上的Asset");
                return null;
            }
            return res;
        }

        public override TextAsset LoadTextAsset(string TextAssetName)
        {
            Object res = Resources.Load(InkStoryPath + TextAssetName);
            if(res == null)
            {
                return null;
            }
            return res as TextAsset;
        }

        public override void SetDays(int day)
        {
            m_Converation.m_CurrectChapter = day;
        }

        public void SetCurrectCheck(int num)
        {
            m_Converation.m_CurrectCheck = num;
        }

        public override string GetDays()
        {
            return m_Converation.Days[m_Converation.m_CurrectChapter];
        }

        public string GetCurrectStory()
        {
            return m_SaveData.m_CurrectStory;
        }

        public string[][] GetDayNeedCheck()
        {
            return m_Converation.DayNeedCheck;
        }

        public string[][] GetDayBeCheck()
        {
            return m_Converation.DayBeCheck;
        }

        public int GetCurrectCheck()
        {
            return m_Converation.m_CurrectCheck;
        }

        public override void NextDays()
        {
            m_Converation.m_CurrectChapter++;
        }

        public void SavePlayerPref()
        {
            m_SaveData.Save();
        }

        public void LoadPlayerPref()
        {
            m_SaveData.Load();
        }

        public void SaveEvilNum(int num)
        {
            m_SaveData.m_EvilNum += num;
        }

        public void SaveCurrectStory(string s)
        {
            m_SaveData.m_CurrectStory = s;
        }

        public void SaveConveration()
        {
            m_SaveData.m_Converation = m_Converation.m_CurrectChapter;
        }

        public void SaveCurrectCheck()
        {
            m_SaveData.m_CurrectCheck = m_Converation.m_CurrectCheck;
        }
    }
}