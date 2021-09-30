using System;
using System.Diagnostics;
public class TestCaseFib
{
    public int X { get; set; }
    public int Expected { get; set; }
    public Exception ExpectedException { get; set; }

    static void TestFibFor(TestCaseFib testCaseFib)
    {
        try
        {
            var actual_1 = Fib.FibRec(testCaseFib.X);

            if (actual_1 == testCaseFib.Expected)
            {
                Console.Write($"Числа Фибоначчи через рекурсию для n = {testCaseFib.X} = {actual_1}\tVALID TEST\n");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        catch (Exception)
        {
            if (testCaseFib.ExpectedException != null)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
    }
    static void TestFibRec(TestCaseFib testCaseFib)
    {
        try
        {
            var actual_1 = Fib.FibFor(testCaseFib.X);

            if (actual_1 == testCaseFib.Expected)
            {
                Console.Write($"Числа Фибоначчи через рекурсию для n = {testCaseFib.X} = {actual_1}\tVALID TEST\n");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        catch (Exception)
        {
            if (testCaseFib.ExpectedException != null)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
    }
    public static void TestCase ()
    {
        Stopwatch sw = new Stopwatch();

        var TestCaseFib_1 = new TestCaseFib()
        {
            X = 1,
            Expected = 1,
            ExpectedException = null
        };

        var TestCaseFib_2 = new TestCaseFib()
        {
            X = 2,
            Expected = 1,
            ExpectedException = null
        };

        var TestCaseFib_3 = new TestCaseFib()
        {
            X = 3,
            Expected = 2,
            ExpectedException = null
        };
        var TestCaseFib_4 = new TestCaseFib()
        {
            X = 4,
            Expected = 3,
            ExpectedException = null
        };
        var TestCaseFib_5 = new TestCaseFib()
        {
            X = -1,
            Expected = 2,
            ExpectedException = null
        };
        sw.Start();
        Console.WriteLine("Тест числа Фибоначчи методом рекурсии:");
        TestFibRec(TestCaseFib_1);
        TestFibRec(TestCaseFib_2);
        TestFibRec(TestCaseFib_3);
        TestFibRec(TestCaseFib_4);
        TestFibRec(TestCaseFib_5);
        sw.Stop();
        Console.WriteLine("Тест занял: " + sw.Elapsed.TotalMilliseconds + " миллисекунд");
        Console.WriteLine();
        sw.Start();
        Console.WriteLine("Тест числа Фибоначчи методом цикла:");
        TestFibFor(TestCaseFib_1);
        TestFibFor(TestCaseFib_2);
        TestFibFor(TestCaseFib_3);
        TestFibFor(TestCaseFib_4);
        TestFibFor(TestCaseFib_5);
        sw.Stop();
        Console.WriteLine("Тест занял: " + sw.Elapsed.TotalMilliseconds + " миллисекунд");
        Console.WriteLine();
    }
}
