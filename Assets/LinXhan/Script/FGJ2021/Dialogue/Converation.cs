using System.Collections;
using UnityEngine;

namespace FGJ2021
{
    public class Converation
    {
        public int m_CurrectChapter = 0;
        public int m_CurrectCheck = 0;
        public string[] Days = {"Day1", "Day2", "Day3"};
        public string[][] DayNeedCheck;
        public string[][] DayBeCheck;

        public void Initialize()
        {
            DayNeedCheck = new string[7][];
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
            DayNeedCheck[4] = new string[]
            {

            };
            DayNeedCheck[5] = new string[]
            {
    
            };
            DayNeedCheck[6] = new string[]
            {

            };

            DayBeCheck = new string[7][];
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
            DayBeCheck[4] = new string[]
            {

            };
            DayBeCheck[5] = new string[]
            {

            };
            DayBeCheck[6] = new string[]
            {

            };
        }
    }
}