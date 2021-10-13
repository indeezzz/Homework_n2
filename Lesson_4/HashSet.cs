using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{    
    [MemoryDiagnoser]
    [RankColumn]
    public class HashSetTest
    {
        public static int n = 10000;
        [Benchmark]
        public bool TestGetMas()
        {           
            string[] mas = new string[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Guid.NewGuid().ToString();
            }

            Random r = new Random();
            string masGuid = mas[r.Next(mas.Length)];
            if(mas.Contains(masGuid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Benchmark]
        public bool TetHashSet()
        {
            HashSet<string> Str = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                Str.Add(Guid.NewGuid().ToString());
                i++;
            }

            Random r = new Random();
            string[] asArray = Str.ToArray();
            string StrGuid = asArray[r.Next(asArray.Length)];

            if (Str.Contains(StrGuid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }   
}
//Тест только для заполнения массива и HashSet.
/*
| Method     | Mean     | Error     | StdDev    | R | Gen 0    | Gen 1   | Gen 2   | Allocated |
| -----------| ---------| ----------| ----------| --| ---------| --------| --------| ----------|
| TestGetMas | 1.775 ms | 0.0055 ms | 0.0049 ms | 2 | 123.0469 | 60.5469 | -       | 1,016 KB  |
| TetHashSet | 1.177 ms | 0.0098 ms | 0.0087 ms | 1 | 82.0313  | 41.0156 | 41.0156 | 784 KB    |
*/
//Тест поиска элемента в массиве и в HashSet при условии, что элементы массива и хэш разные, и соотвественно искомые элементы разные
/*
| Method     | Mean     | Error     | StdDev    | Rank | Gen 0    | Gen 1   | Gen 2   | Allocated |
| -----------| ---------| ----------| ----------| -----| ---------| --------| --------| ----------|
| TestGetMas | 1.750 ms | 0.0059 ms | 0.0055 ms | 2    | 123.0469 | 41.0156 | -       | 1,016 KB  |
| TetHashSet | 1.270 ms | 0.0095 ms | 0.0089 ms | 1    | 99.6094  | 58.5938 | 39.0625 | 823 KB    |
*/

// Если судить по тесту при условии, что все сделано правильно можно сделать вывод, что все таки с хэшом быстрей выполняется и наполнение, и поиск элементов. При этом места в памяти он занимает меньше.