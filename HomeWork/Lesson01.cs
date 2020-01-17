using System;
using System.Globalization;

namespace MkGame
{
    /**********************************
     *  Сергей Михасько
     **********************************/
    class Lesson01
    {
        //---------------------------------------------------------------------------------------------------
        // Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
        // В результате вся информация выводится в одну строчку:
        //---------------------------------------------------------------------------------------------------
        public static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Анкета");

            Console.WriteLine("Имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Фамилия:");
            string surname = Console.ReadLine();
            byte year =  (byte)Utility.InputCorrectData("Возраст / лет", 0, 100);
            float height = (float)Utility.InputCorrectData("Рост / м", 0, 3);
            float weight = (float)Utility.InputCorrectData("Вес / кг", 0, 300);

            Console.WriteLine("Вы ввели: ");
            Console.WriteLine("Имя: " + name + " Фамилия: " + surname + " Возрас: " + year + " Рост: " +
                height + " Вес: " + weight);
            Console.WriteLine($"Имя: {name} Фамилия: {surname} Возраст: {year} Рост: {height} Вес: {weight}");
            Console.WriteLine("Имя: {0} Фамилия: {1} Возраст: {2} Рост: {3} Вес: {4}", name , surname , year , height , weight);
        }
        //---------------------------------------------------------------------------------------------------
        // Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
        // где m — масса тела в килограммах, h — рост в метрах. Написать программу «Анкета». 
        //---------------------------------------------------------------------------------------------------
        public static void Task2()
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
                correct.ToString ("F01"));

        }
        //---------------------------------------------------------------------------------------------------
        // Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
        //---------------------------------------------------------------------------------------------------
        public static void Task3()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите координаты двух точек.");
            double a_x = Utility.InputCorrectData("PoinA_x", double.MinValue, double.MaxValue);
            double a_y = Utility.InputCorrectData("PoinA_y", double.MinValue, double.MaxValue);
            double b_x = Utility.InputCorrectData("PoinB_x", double.MinValue, double.MaxValue);
            double b_y = Utility.InputCorrectData("PoinB_y", double.MinValue, double.MaxValue);


            Console.WriteLine($"PointA(x = {a_x} y = {a_y})  PointB(x = {b_x} y = {b_y})");
            double dist = Utility.DistPoints(a_x, a_y, b_x, b_y);

            Console.WriteLine("D(PoinA, PointB) = " + dist.ToString("F02"));
        }
        //---------------------------------------------------------------------------------------------------
        // Написать программу обмена значениями двух переменных:
        // а) с использованием третьей переменной;
        // б) *без использования третьей переменной.
        //---------------------------------------------------------------------------------------------------
        public static void Task4()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            //------------------------------------------
            //  с использованием 3 переменной 
            //------------------------------------------
            float a = 12.5f;
            float b = 50.0f;
            Console.WriteLine("Исходные: a = {0} b = {1}", a, b);   // 12.5    50.0

            float t = a;
            a = b;
            b = t;
            Console.WriteLine("Перестановка: a = {0} b = {1}", a, b);   // 50.0    12.5
            //------------------------------------------
            //  только 2 переменные       
            //------------------------------------------
            Console.WriteLine("Исходные: a = {0} b = {1}", a, b);
            a = b + a;
            b = a - b;
            a = a - b;
            Console.WriteLine("Перестановка: a = {0} b = {1}", a, b);   // 50.0    12.5

            //------------------------------------------
            //  частный случай для int переменных
            //------------------------------------------
            int iA = 50;
            int iB = 100;
            Console.WriteLine("Исходные: a = {0} b = {1}", iA, iB);   // 50   100

            iA = iA ^ iB;
            iB = iB ^ iA;
            iA = iA ^ iB;
            Console.WriteLine("Перестановка: a = {0} b = {1}", iA, iB);   // 100   50
        }
        //---------------------------------------------------------------------------------------------------
        // Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
        // б) *Сделать задание, только вывод организовать в центре экрана.
        // в) **Сделать задание с использованием собственных методов(например, Print(string ms, int x, int y).
        //---------------------------------------------------------------------------------------------------
        public static void Task5()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            string[] messages = { "Mikhasko Sergej", "Zhukovsky" };
            Utility.PrintCenter('+', 6, 2, messages);
        }
    }   
}
