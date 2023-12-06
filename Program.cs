using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTime
{
    class Program
    {
        static MyTime Time()
        {
            Console.Write("Введiть години:");
            int h = int.Parse(Console.ReadLine());
            Console.Write("Введiть хвилини:");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введiть секунди:");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine();
            MyTime time = new MyTime(h, m, s);
            return time;
        }
        static void Main(string[] args)
        {
            MyTime time = Time();
            Console.WriteLine(time);

            Console.WriteLine();
            int seconds = time.ToSecSinceMidnight();
            Console.WriteLine("Пройшло секунд з початку доби: " + seconds);
            MyTime t2 = time.FromSecSinceMidnight(seconds);
            Console.WriteLine("Перетвореннi секунди з початку доби: " + t2);
            Console.WriteLine();

            MyTime sAdd1 = time.AddOneSecond(seconds);
            Console.WriteLine("Додамо одну секунду: " + sAdd1);

            MyTime mAdd1 = time.AddOneMinute(seconds);
            Console.WriteLine("Додамо одну хвилину: " + mAdd1);

            MyTime hAdd1 = time.AddOneHour(seconds);
            Console.WriteLine("Додамо одну годину: " + hAdd1);

            Console.WriteLine("Введiть секунди, якi хочете додати:");
            int secAdd = int.Parse(Console.ReadLine());
            MyTime addSecond = time.AddSeconds(seconds, secAdd);
            Console.WriteLine("Вiдповiдь:" + addSecond);

            Console.WriteLine("Введіть час для рiзницi.");
            MyTime time2 = Time();
            Console.WriteLine("Ваш час: " + time2);

            int differenceInSeconds = time.Difference(time, time2);
            MyTime differenceMT = time.FromSecSinceMidnight(differenceInSeconds);
            Console.WriteLine();
            Console.WriteLine("Рiзниця: " + differenceMT);
            Console.WriteLine();

            Console.WriteLine("Введiть час початку промiжку.");
            MyTime start = Time();
            Console.WriteLine("Введiть час кiнця промiжку.");
            MyTime finish = Time();
            Console.WriteLine("Ваш початковий час: " + start);
            Console.WriteLine("Ваш кiнцевий час: " + finish);
            Console.WriteLine();

            bool isInRange = time.IsInRange(start, finish, time);
            Console.WriteLine(isInRange);

            Console.WriteLine(time.WhatLesson());

            Console.ReadKey();
        }
    }
}
