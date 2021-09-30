using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCaseFactorial.TestCase();
            TestCaseFib.TestCase();
            Console.WriteLine("Асимптотическая сложность функции StrangeSum: O(n^3)");
            Console.WriteLine();
            FuncСomplexity.Func();
        }
    }
}
