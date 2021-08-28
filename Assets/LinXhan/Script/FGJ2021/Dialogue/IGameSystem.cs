using System;
using System.Collections;
using UnityEngine;

namespace FGJ2021
{
    public class IGameSystem
    {
        public Action m_DelegateInitialize;
        public Action m_DelegateGameSystemUpdate;
        public Action m_DegegateRelease;

        public virtual void Initialize()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Release()
        {

        }
    }
}