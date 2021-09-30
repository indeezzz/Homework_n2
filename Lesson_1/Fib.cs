public class Fib
{
    public static int FibRec(int n)
    {
        return n <= 1 ? n : FibRec(n - 1) + FibRec(n - 2);
    }
    public static int FibFor(int n)
    {
        int a = 0;
        int b = 1;
        int tmp;

        for (int i = 0; i < n; i++)
        {
            tmp = a;
            a = b;
            b += tmp;
        }

        return a;
    }
}
