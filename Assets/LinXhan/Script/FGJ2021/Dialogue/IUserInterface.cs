using System;
using UnityEngine;

namespace FGJ2021
{
    public class IUserInterface : MonoBehaviour
    {
        public Action m_DelegateInitialize;
        public Action m_DelegateUpdate;
        public Action m_DegegateRelease;

        private bool active = true;

        public virtual void Initialize()
        {

        }

        public virtual void UIUpdate()
        {

        }

        public virtual void Release()
        {
            Destroy(gameObject); //TODO:直接消除會有BUG，要用List
        }
    }
}