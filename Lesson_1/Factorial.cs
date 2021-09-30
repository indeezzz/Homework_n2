public class Factorial
{
       public static long FactorialFor(int n)
        {
            long factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        public static long FactorialRec(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * FactorialRec(n - 1);
            }
        }
}
