using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Lesson_3
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Distance
    {
        ClassPoint A = new ClassPoint((float)1.1, (float)1.1);
        ClassPoint B = new ClassPoint((float)4.1, (float)4.1);
        StructPoint D = new StructPoint((float)2.2, (float)2.2);
        StructPoint E = new StructPoint((float)6.1, (float)5.1);
        public static float DistancePoints(ClassPoint A, ClassPoint B)
        {
            float x = (float)A.X - (float)B.X;
            float y = (float)A.Y - (float)B.Y;
            float result = MathF.Sqrt((x * x) + (y * y));
            return result;
        }

        public static float DistancePoints(StructPoint C, StructPoint D)
        {
            float x = (float)C.X - (float)D.X;
            float y = (float)C.Y - (float)D.Y;
            float result = MathF.Sqrt((x * x) + (y * y));
            return result;
        }

        public static double PointDistanceShortDouble(StructPoint C, StructPoint D)
        {
            double x = C.X - D.X;
            double y = C.Y - D.Y;
            double result = (x * x) + (y * y);
            return result;
        }

        public static float  PointDistanceShort(StructPoint C, StructPoint D)
        {
            float x = (float)C.X - (float)D.X;
            float y = (float)C.Y - (float)D.Y;
            float result = (x * x) + (y * y);
            return result;
        }
        [Benchmark]
        public void TestDistancePointsClass()
        {
            DistancePoints(A, B);
        }
        [Benchmark]
        public void TestDistancePointsStruct()
        {
            DistancePoints(D, E);
        }

        [Benchmark]
        public void TestDistancePointsStructDouble()
        {
            PointDistanceShortDouble(D, E);
        }

        [Benchmark]
        public void TestDistancePointsStructShort()
        {
            PointDistanceShort(D, E);
        }

    }
}
