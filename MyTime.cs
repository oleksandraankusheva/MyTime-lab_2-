using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTime
{
    class MyTime
    {
        private int hour, minute, second;

        public MyTime(int h, int m, int s)
        {
            this.hour = h;
            this.minute = m;
            this.second = s;
        }
        public override string ToString()
        {
            return $"{hour}:{minute:D2}:{second:D2}";
        }
        public int ToSecSinceMidnight() //секунди з початку доби
        {
            return hour * 3600 + minute * 60 + second;
        }

        public MyTime FromSecSinceMidnight(int seconds) //час з початку доби за допомогою секунд
        {
            int secPerDay = 86400; //секунд в добі
            seconds %= secPerDay;
            // приводимо t до проміжку, можливого в межах однієї доби,
            // враховуючи, що початкове значення t може бути й від’ємним
            if (seconds < 0)
                seconds += secPerDay;
            hour = seconds / 3600;
            minute = (seconds / 60) % 60;
            second = seconds % 60;
            return new MyTime(hour, minute, second);
        }

        public MyTime AddOneSecond(int seconds) //додамо одну секунду
        {
            second = (seconds + 1) % 86400;
            return FromSecSinceMidnight(second);
        }

        public MyTime AddOneMinute(int seconds) //додамо одну хвилину
        {
            minute = (seconds + 60) % 86400;
            return FromSecSinceMidnight(minute);
        }
        public MyTime AddOneHour(int seconds)  //додаємо одну годину
        {
            hour = (seconds + 3600) % 86400;
            return FromSecSinceMidnight(hour);
        }

        public MyTime AddSeconds(int seconds, int secAdd)  //додаємо певну кількість секунд
        {
            second = (seconds + secAdd) % 86400;
            return FromSecSinceMidnight(second);
        }
        public int Difference(MyTime mt1, MyTime mt2)
        {
            int secondMT1 = mt1.ToSecSinceMidnight();
            int secondMT2 = mt2.ToSecSinceMidnight();
            return secondMT1 - secondMT2;
        }

        public bool IsInRange(MyTime start, MyTime finish, MyTime time) //чи належить певному проміжку часу
        {
            int startSec = start.ToSecSinceMidnight();
            int finishSec = finish.ToSecSinceMidnight();
            int timeSec = time.ToSecSinceMidnight();

            if (startSec <= finishSec)
            {
                return timeSec >= startSec && timeSec <= finishSec;
            }
            else
            {
                return timeSec >= startSec || timeSec <= finishSec;
            }
        }

        public string WhatLesson()
        {
            MyTime[,] lessons = new MyTime[6, 2]
            {
            { new MyTime(8, 0, 0), new MyTime(9, 20, 0) },
            { new MyTime(9, 40, 0), new MyTime(11, 0, 0) },
            { new MyTime(11, 20, 0), new MyTime(12, 40, 0) },
            { new MyTime(13, 0, 0), new MyTime(14, 20, 0) },
            { new MyTime(14, 40, 0), new MyTime(16, 0, 0) },
            { new MyTime(16, 10, 0), new MyTime(17, 30, 0) }
            };

            if (hour < 8)
            {
                return "Пари ще не почалися";
            }
            int lessonsIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                if (IsInRange(lessons[i, 0], lessons[i, 1], this))
                {
                    lessonsIndex = i;
                    break;
                }
                else if (i < 5 && IsInRange(lessons[i, 1], lessons[i + 1, 0], this))
                {
                    return $"Перерва між {i + 1}-ю та {i + 2}-ю парами.";
                }
            }

            if (!IsInRange(lessons[0, 0], lessons[5, 1], this))
            {
                return "Пари вже скiнчилися.";
            }

            return (lessonsIndex + 1) + "-а пара.";
        }
    }
}
