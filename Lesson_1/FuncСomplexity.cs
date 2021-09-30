using System;

namespace Lesson_1
{
    class FuncСomplexity
    {
        public static void Func()
        {
            Console.WriteLine("Определение сложности числа:");
            Console.WriteLine("Укажите целочисленое число: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            if (d == 0)
            {
                Console.WriteLine("Чисо простое");
            }
            else
            {
                Console.WriteLine("Чисо не простое");
            }
        }
    }
}
