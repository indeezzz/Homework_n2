using BenchmarkDotNet.Running;
using System;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<HashSetTest>();
            TestTree.TestTreeNode();
        }
    }
}
