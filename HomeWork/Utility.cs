using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace MkGame
{
    class Utility
    {
        // расстояние между точками
        public static double DistPoints(double x1, double y1, double x2, double y2)
        {
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return r;
        }
        // обработка ввода данных
        public static double InputCorrectData(string message, double min, double max)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(message + " :");
                try
                {
                    // для устранения неоднозначности десятичного разделителя
                    CultureInfo myCIintl = new CultureInfo("en-US", false);
                    string s = Console.ReadLine();
                    s = s.Replace(',', '.');

                    double k = Convert.ToDouble(s, myCIintl);

                    if (k <= min || k >= max)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите реальные данные!");
                        continue;
                    }
                    return k;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные введены некорректно!");
                }
            }
        }

        // *   message  *
        public static void Print(string message, int x, int y, int lenght, char ch)
        {
            if (lenght < message.Length + 2) return;

            Console.CursorTop = y;
            Console.CursorLeft = x;

            int d_space = (lenght - 2) - message.Length;
            int space = d_space / 2;

            Console.WriteLine(ch + new string(' ', space) + message + new string(' ', d_space - space) + ch);
        }
        /// <summary>
        /// Многострочная печать
        /// </summary>
        /// <param name="x">Левый верхний угол</param>
        /// <param name="y">Левый верхний угол</param>
        /// <param name="ch">Символ для декорации</param>
        /// <param name="spaceX">Пробелов отступа по горизонтали</param>
        /// <param name="spaceY">Пробелов отступа по вертикали</param>
        /// <param name="messages">Сообщения</param>
        public static void Print(int x, int y, char ch, int spaceX, int spaceY, params string[] messages)
        {
            int lenght = 0;

            foreach (string s in messages)
                if (s.Length > lenght) lenght = s.Length;

            lenght = lenght + 2 * spaceX + 2;


            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.WriteLine(new string(ch, lenght));

            for (int i = 0; i < spaceY; i++)
            {
                Console.CursorLeft = x;
                Console.WriteLine(ch + new string(' ', lenght - 2) + ch);
            }

            y = Console.CursorTop;
            for (int i = 0; i < messages.Length; i++)
            {
                Print(messages[i], x, y + i, lenght, ch);
            }

            for (int i = 0; i < spaceY; i++)
            {
                Console.CursorLeft = x;
                Console.WriteLine(ch + new string(' ', lenght - 2) + ch);
            }

            Console.CursorLeft = x;
            Console.WriteLine(new string(ch, lenght));
        }
        /// <summary>
        /// Печать по центру окна
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="spaceX">Пробелов отступа по горизонтали</param>
        /// <param name="spaceY">Пробелов отступа по вертикали</param>
        /// <param name="messages"></param>
        public static void PrintCenter(char ch, int spaceX, int spaceY, params string[] messages)
        {
            int width = 0;
            int height = 0;

            // длина максимальной строки
            foreach (string s in messages)
                if (s.Length > width) width = s.Length;

            width = width + 2 * spaceX + 2;
            height = messages.Length + 2 * spaceY + 2;

            int xPos = (Console.WindowWidth - width) / 2;
            int yPos = (Console.WindowHeight - height) / 2;

            Print(xPos, yPos, ch, spaceX, spaceY, messages);
        }
    }
}
