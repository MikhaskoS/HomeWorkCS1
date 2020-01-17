using System;
using System.Collections.Generic;
using System.Text;

namespace MkGame
{
    /**********************************
     *  Сергей Михасько
     **********************************/
    class Lesson02
    {
        //---------------------------------------------------------------------------------------------
        //   минимальное из 3 чисел
        //---------------------------------------------------------------------------------------------
        #region
        public static void Task1()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Random rand = new Random();
            int a = rand.Next(0, 100);
            int b = rand.Next(0, 100);
            int c = rand.Next(0, 100);
            Console.WriteLine($"a = {a} b = {b} c = {c} min = {Min(a, b, c)}");
        }
        // минимальное из 3 чисел
        public static double Min(double a, double b, double c)
        {
            double min = c;
            if (b < min) min = b;
            if (a < min) min = a;

            return min;
        }
        #endregion
        //---------------------------------------------------------------------------------------------
        // Количество цифр числа
        //---------------------------------------------------------------------------------------------
        #region
        public static void Task2()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Random rand = new Random();
            double a = rand.Next(-int.MaxValue, int.MaxValue) * rand.NextDouble();

            Console.WriteLine($"a = {-a} Цифр: {CountNum(-a)}");

            int b = rand.Next(0, int.MaxValue);
            Console.WriteLine($"b = {b} Цифр: {CountNum(b)}");
        }
        // подсчет количества цифр
        public static int CountNum(double number)
        {
            if (number < 0) number = -number;
            string s = number.ToString();
            string[] str = s.Split(new char[] { '.', ',' });

            if (str.Length > 1) return str[0].Length + str[1].Length;
            else return str[0].Length;
        }
        // подсчет количества цифр для целого числа
        // [0-9] - 1 < 10^1  [10-99] - 2 < 10^2 [100 - 999] < 10^3 [1000 - 9999] < 10^4 ...
        public static int CountNum(int number)
        {
            double d = Math.Log10(number);
            return (int)d + 1;
        }
        #endregion
        //---------------------------------------------------------------------------------------------
        // Подсчет нечетных положительных цифр с клавиатуры
        //---------------------------------------------------------------------------------------------
        #region
        public static void Task3()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Вводите цифры. 0 - выход.");

            int sum = 0;
            bool exit = false;
            while (!exit)
            {
                char ch = Console.ReadKey(true).KeyChar;
                if (Char.IsDigit(ch))
                {
                    Console.Write(ch);

                    int n = Convert.ToInt16(ch) - 48;  // Unicode(ASCII) -> int
                    if (n % 2 != 0) sum += n;
                }

                if (ch == '0') exit = true;
            }

            Console.WriteLine("\nСумма нечетных цифр: " + sum);
        }
        #endregion
        //---------------------------------------------------------------------------------------------
        // Пароль
        //---------------------------------------------------------------------------------------------
        #region
        public static void Task4()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            int attempt = 0; // число попыток
            bool enter = false;

            Console.WriteLine($"Введите логин [{LOG}] и пароль [{PASS}]");
            while (!enter)
            {
                attempt++;

                Console.WriteLine($"Попытка: {attempt}");
                Console.Write("Логин: >");
                string log = Console.ReadLine();
                Console.Write("Пароль: >");
                string pas = Console.ReadLine();

                enter = CheckPass(log, pas);

                if (!enter && attempt == 3)
                    break;
            }

            if (enter) Console.WriteLine("Добро пожаловать!");
            else
                Console.WriteLine("До свидания!");
        }

        private static string PASS = "GeekBrains";
        private static string LOG = "root";

        public static bool CheckPass(string log, string pass)
        {
            if (pass == PASS && log == LOG) return true;
            else return false;
        }
        #endregion
        //---------------------------------------------------------------------------------------------
        //   ИМТ
        //---------------------------------------------------------------------------------------------
        #region
        public static void Task5()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ИМТ ");
            double weight = Utility.InputCorrectData("Вес / кг", 0, 300);
            double height = Utility.InputCorrectData("Рост / м", 0, 3);

            double bmi = weight / (height * height);
            double correct = 0;
            if (bmi < 18.51)
            {
                double w_norm = 18.55 * (height * height);
                correct = w_norm - weight;
            }
            else if (bmi > 24.99)
            {
                double w_norm = 24.99 * (height * height);
                correct = w_norm - weight;
            }

            string verdict = "Очень резкое ожирение";
            if (bmi < 16) verdict = "Выраженный дефицит массы тела";
            else if (bmi < 18.5) verdict = "Недостаточная (дефицит) масса тела";
            else if (bmi < 24.99) verdict = "Норма";
            else if (bmi < 30) verdict = "Избыточная масса тела (предожирение)";
            else if (bmi < 35) verdict = "Ожирение";
            else if (bmi < 40) verdict = "Ожирение резкое";

            Console.WriteLine("ИМТ: {0}", bmi.ToString("F02"));
            Console.WriteLine(verdict);
            Console.WriteLine("Необходимая корректировка веса: {0} кг",
                correct.ToString("F01"));
        }
        #endregion
        //---------------------------------------------------------------------------------------------
        // *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
        // «Хорошим» называется число, которое делится на сумму своих цифр.Реализовать
        // подсчёт времени выполнения программы, используя структуру DateTime.
        //---------------------------------------------------------------------------------------------
        #region
        public static void Task6()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            int max = 1_000_000_00;

            Console.WriteLine($"Подсчет хороших чисел до {max}");
            Console.WriteLine($"Для 1 000 000 000 приблизительное время 86 и 50 сек!");

            long t0 = 0;
            long t1 = 0;
            int goodNum = 0;

            t0 = DateTime.Now.Ticks;

            goodNum = GoodNumStandard(max);

            t1 = DateTime.Now.Ticks;

            Console.WriteLine("OK: " + goodNum);
            Console.WriteLine("Время вычислений: " + (t1 - t0) * 0.0000001f + "сек.");  //(6954792 : 7.8) -> (61574509: 86 сек)

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            t0 = DateTime.Now.Ticks;

            goodNum = GoodNum(max);

            t1 = DateTime.Now.Ticks;

            Console.WriteLine("OK: " + goodNum);
            Console.WriteLine("Время вычислений: " + (t1 - t0) * 0.0000001f + "сек.");  //(6954792 : 4.3) -> (61574509: 50 сек)
        }
        #region способ 1
        public static int GoodNumStandard(int max)
        {
            int result = 0;
            for (int i = 1; i < max; i++)
            {
                int sum = SumNum(i);

                if (i % sum == 0)
                {
                    result++;
                    //Console.WriteLine($"num = {i} sum = {sum} num/sum = {i / sum}");
                }
            }
            return result;
        }
        // сумма цифр
        public static int SumNum(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
        #endregion

        #region способ 2
        // Избавляемся от операций деления и умножения
        public static int GoodNum(int max)
        {
            int result = 0;

            int n = 0; // сумма цифр
            int[] test = TestedArray(max);
            int[] test0 = TestedArray(max);
            int[] diff = Difference(max);

            for (int i = 1; i < max; i++)
            {
                n += 1;
                n = n - IncrementArray(test, test0, diff);

                if (i % n == 0) result++;
                //Console.WriteLine($"num = {i} sum = {n} num/sum = {i / n}");
            }

            return result;
        }

        // создаем массив-светофор
        static int[] TestedArray(int max)
        {
            // для 10 это просто {10}
            // для 100 {10, 100}
            // для 1 000 000 000 {10 ,100 ,1000, 10 000, 100 000, 1 000 000, 10 000 000, 100 000 000, 1 000 000 000}

            int n = (int)Math.Log10(max);
            int[] t = new int[n];

            t[0] = 10;
            for (int i = 1; i < n; i++)
            { 
                t[i] = t[i - 1] * 10; 
            }

            return t;
        }
        // заметим что через 10 сумма цифр меняется на -8  (19 -> 20 это 10 -> 10-8)
        //             через 100 на - (9+9)                (199 -> 200 это 19 -> 19-8-9)
        //             через 1000 на - (9+9+9) ...         (1999 -> 2000 это 28 -> 28-8-9-9)
        // рассчитаем эту разность для каждого шага в цикле
        // // для 1 000 000 000 {9 ,18 ,27, 36, 45, 54, 63, 72, 81}
        static int[] Difference(int max)
        {
            int n = (int)Math.Log10(max);
            int[] t = new int[n];

            t[0] = 9; // 9 а не 8 из-за особенности цикла в GoodNum
            for (int i = 1; i < n; i++)
            {
                t[i] = t[i - 1] + 9;
            }

            return t;
        }

        // уменьшаем элементы массива на 1 и при достижении 0 показываем,
        // на какое значение уменьшается сумма цифр
        static int IncrementArray(int[] test, int[] test0, int[] diff)
        {
            bool solve = false;
            int n = 0;

            for (int i = test.Length - 1; i >= 0; i--)
            {
                test[i] = test[i] - 1;
                if (test[i] == 0)
                {
                    if (!solve)
                    {
                        solve = true;
                        n = diff[i];
                    }
                    test[i] = test0[i];
                }
            }
            return n;
        }
        #endregion
        #endregion
        //---------------------------------------------------------------------------------------------
        // a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        // б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
        //---------------------------------------------------------------------------------------------
        #region
        public static void Task7()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            int a = 1;
            int b = 15;
            Console.WriteLine($"Вывод чисел на экран от {a} до {b}");

            PrintNum(a, b);

            Console.WriteLine("\nСумма чисел: " + Sum(a, b));
        }

        public static void PrintNum(int a, int b)
        {
            if (a < b)
            {
                Console.Write($"{a}  ");
                a++;

                PrintNum(a, b);
            }
            else
                Console.Write($"{a}  ");
        }

        private static int Sum(int a, int b)
        {
            int res = a;
            if (a < b)
            {
                a++;
                res = res + Sum(a, b);
            }

            return res;
        }
        #endregion
    }
}
