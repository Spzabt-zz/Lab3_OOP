using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP_PartTwo
{
    class MyTime
    {
        public int Hour;
        public int Minute;
        public int Second;

        public MyTime(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }

        public MyTime() { }

        public int TimeSinceMidnight(MyTime t)
        {
            return t.Hour * 3600 + t.Minute * 60 + t.Second;
        }

        public MyTime TimeSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t = ((t % secPerDay) + secPerDay) % secPerDay;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;

            return new MyTime(h, m, s);
        }

        public MyTime AddOneSecond(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 1);
        }

        public MyTime AddOneMinute(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 60);
        }

        public MyTime AddOneHour(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 3600);
        }

        public MyTime AddSeconds(MyTime t, int s)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + s);
        }

        public int Difference(MyTime mt1, MyTime mt2)
        {
            return TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
        }

        public string WhatLesson(MyTime mt)
        {
            string messageOne = "пари не почались.";
            string messageTwo = "Пари закінчились.";

            int[] breaksLength = { 20, 20, 20, 20, 10, 10, 0 };

            MyTime startTime = new MyTime(8, 0, 0);
            //14:20:10
            if (Difference(mt, startTime) <= 0)
            {
                return messageOne;
            }
            for (int lessonNum = 0; lessonNum < breaksLength.Length; lessonNum++)
            {
                startTime = AddSeconds(startTime, 80 * 60);
                if (Difference(mt, startTime) < 0)
                {
                    return string.Format($"{lessonNum + 1} - а пара.");
                }
                startTime = AddSeconds(startTime, breaksLength[lessonNum] * 60);
                if (lessonNum == breaksLength.Length - 1)
                {
                    break;
                }
                if (Difference(mt, startTime) <= 0)
                {
                    return string.Format($"Перерва між {lessonNum + 1}-ю та {lessonNum + 2}-ю парами");
                }
            }

            return messageTwo;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1:00}:{2:00}", Hour, Minute, Second);
        }
    }
}