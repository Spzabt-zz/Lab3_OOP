using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP_PartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;

            MyTime myTime = new MyTime();

            while (isOpen)
            {
                Console.Write("Введіть години: ");
                myTime.Hour = int.Parse(Console.ReadLine());
                Console.Write("Введіть хвилини: ");
                myTime.Minute = int.Parse(Console.ReadLine());
                Console.Write("Введіть секунди: ");
                myTime.Second = int.Parse(Console.ReadLine());

                Console.WriteLine($"{myTime} - {myTime.WhatLesson(myTime)}");

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}