using System.Collections;
using UnityEngine;

namespace FGJ2021_LinXhan
{
    public class Converation
    {
        public int m_CurrectCDay = 0;
        public int m_CurrectCheck = 0;
        public int m_FinalDay = 4;
        public string[] Days = {"Day1", "Day2", "Day3"};
        public string[][] DayNeedCheck;
        public string[][] DayBeCheck;

        public void Initialize()
        {
            DayNeedCheck = new string[m_FinalDay][];
            DayNeedCheck[0] = new string[]
            {
                "gift",
                "shirtcolor",
                "nightmare"
            };
            DayNeedCheck[1] = new string[]
            {

            };
            DayNeedCheck[2] = new string[]
            {

            };
            DayNeedCheck[3] = new string[]
            {

            };

            DayBeCheck = new string[m_FinalDay][];
            DayBeCheck[0] = new string[]
            {

            };
            DayBeCheck[1] = new string[]
            {
                "book",
                "yellow",
                "yes"
            };
            DayBeCheck[2] = new string[]
            {

            };
            DayBeCheck[3] = new string[]
            {

            };
        }

        public void FinalDay()
        {
            //TODO:設置結局
        }
    }
}