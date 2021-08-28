using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FGJ2021
{
    public abstract class IResources
    {
        public abstract Sprite LoadSprite(string SpriteName);
        public abstract GameObject LoadUI(string UIName);
        public abstract Sprite LoadCharacterAvatar(string CharacterAvatarName);
        public abstract TextAsset LoadTextAsset(string TextAsset);
        public abstract void SetDays(int day);
        public abstract void NextDays();

        public abstract string GetDays();
    }

}

