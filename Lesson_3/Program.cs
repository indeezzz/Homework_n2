using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_3
{
    class Program
    {        
        public  static void Main(string[] args)
        {
            BenchmarkRunner.Run<Distance>();
        }
        
    }
}
