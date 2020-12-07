using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Semestr_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTime time = new MyTime(16, 30, 10);
            MyTime firstMomentOfTime = new MyTime(10, 15, 30);
            MyTime secondMomentOfTime = new MyTime(7, 5, 5);

            Console.WriteLine($"{time} - заданий час.");
            Console.WriteLine($"{TimeSinceMidnight(time)}(сек) - переводить заданий час в секунди.");
            Console.WriteLine($"{AddOneSecond(time)} - додає до часу секунду.");
            Console.WriteLine($"{AddOneMinute(time)} - додає до часу хвилину.");
            Console.WriteLine($"{AddOneHour(time)} - додає до часу годину.");
            Console.Write("Ніпишіть кількість секунд яка вам потрібна: ");
            Console.WriteLine($"{AddSeconds(time, int.Parse(Console.ReadLine()))} - додано секунд.");
            Console.WriteLine($"Заданий час №1 {firstMomentOfTime} - заданий час №2 {secondMomentOfTime}");
            Console.WriteLine($"{TimeSinceMidnight(Difference(firstMomentOfTime, secondMomentOfTime))} - різниця між цими моментами часу.");

            int[] arr = new int[3];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                    Console.Write("Введіть години: ");

                else if (i == 1)
                    Console.Write("Введіть хвилини: ");

                else
                    Console.Write("Введіть секунди: ");

                arr[i] = int.Parse(Console.ReadLine());
            }

            MyTime mt;
            mt.hour = arr[0];
            mt.minute = arr[1];
            mt.second = arr[2];
            Console.WriteLine($"{mt} - {WhatLesson(mt)}");

            Console.ReadKey();
        }

        static int TimeSinceMidnight(MyTime t)
        {
            return t.hour * 3600 + t.minute * 60 + t.second;
        }

        static MyTime TimeSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t = ((t % secPerDay) + secPerDay) % secPerDay;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }

        static MyTime AddOneSecond(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 1);
        }

        static MyTime AddOneMinute(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 60);
        }

        static MyTime AddOneHour(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 3600);
        }

        static MyTime AddSeconds(MyTime t, int s)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + s);
        }

        static int Difference(MyTime mt1, MyTime mt2)
        {
            return TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
        }

        static string WhatLesson(MyTime mt)
        {
            int[] breaksLen = { 20, 20, 20, 20, 10, 10, 0 };

            MyTime timeX = new MyTime(8, 0, 0);
            if (Difference(mt, timeX) <= 0)
            {
                return "пари не почалися";
            }
            for (int smallNum = 0; smallNum < breaksLen.Length; smallNum++)
            {
                timeX = AddSeconds(timeX, 80 * 60);
                if (Difference(mt, timeX) < 0)
                {
                    return string.Format($"{smallNum + 1} - а пара");
                }
                timeX = AddSeconds(timeX, breaksLen[smallNum] * 60);
                if (smallNum == breaksLen.Length - 1)
                {
                    break;
                }
                if (Difference(mt, timeX) <= 0)
                {
                    return string.Format($"перерва між {smallNum + 1}-ю та {smallNum + 2}-ю парами");
                }
            }
            return "Пари вже скінчилися";
        }
    }

    struct MyTime
    {
        public int hour, minute, second;
        public MyTime(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }
        public override string ToString()
        {
            return string.Format("{0}:{1:00}:{2:00}", hour, minute, second);
        }
    }
}