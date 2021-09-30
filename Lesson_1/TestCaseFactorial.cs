using System;
using System.Diagnostics;
public class TestCaseFactorial
{    
    public int X { get; set; }
    public long Expected { get; set; }
    public Exception ExpectedException { get; set; }

    public static void TestFactorialRec(TestCaseFactorial testCaseFactorial)
    {
        try
        {

            var actual_1 = Factorial.FactorialFor(testCaseFactorial.X);

            if (actual_1 == testCaseFactorial.Expected)
            {
                Console.Write($"Факториал через рекурсию при n = {testCaseFactorial.X} = { actual_1}\tVALID TEST\n");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        catch (Exception)
        {
            if (testCaseFactorial.ExpectedException != null)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
    }

    public static void TestFactorialFor(TestCaseFactorial testCaseFactorial)
    {
        try
        {
            var actual_2 = Factorial.FactorialRec(testCaseFactorial.X);

            if (actual_2 == testCaseFactorial.Expected)
            {
                Console.Write($"Факториал через цикл при n = {testCaseFactorial.X} = {actual_2}\tVALID TEST\n");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        catch (Exception)
        {
            if (testCaseFactorial.ExpectedException != null)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
    }

    public static void TestCase()
    {
        Stopwatch sw = new Stopwatch();

        var TestCaseFactorial_1 = new TestCaseFactorial()
        {
            X = 1,
            Expected = 1,
            ExpectedException = null
        };

        var TestCaseFactorial_2 = new TestCaseFactorial()
        {
            X = 2,
            Expected = 2,
            ExpectedException = null
        };

        var TestCaseFactorial_3 = new TestCaseFactorial()
        {
            X = 3,
            Expected = 6,
            ExpectedException = null
        };
        var TestCaseFactorial_4 = new TestCaseFactorial()
        {
            X = 15,
            Expected = 1307674368000,
            ExpectedException = null
        };
        sw.Start();
        Console.WriteLine("Тест факториала методом цикла:");
        TestFactorialFor(TestCaseFactorial_1);
        TestFactorialFor(TestCaseFactorial_2);
        TestFactorialFor(TestCaseFactorial_3);
        TestFactorialFor(TestCaseFactorial_4);
        sw.Stop();
        Console.WriteLine("Тест занял: " + sw.Elapsed.TotalMilliseconds + " миллисекунд");
        Console.WriteLine();

        sw.Start();
        Console.WriteLine("Тест факториала методом рекурсии:");
        TestFactorialRec(TestCaseFactorial_1);
        TestFactorialRec(TestCaseFactorial_2);
        TestFactorialRec(TestCaseFactorial_3);
        TestFactorialRec(TestCaseFactorial_4);
        sw.Stop();
        Console.WriteLine("Тест занял: " + sw.Elapsed.TotalMilliseconds + " миллисекунд");
        Console.WriteLine();
    }
}
