using System;
using System.Collections.Generic;
using System.Linq;
namespace Lesson_2
{
    class BinarySearch
    {
        public static int[] mass = new int[] { 1, 2, 3, 4, 5 };
        public static int BiSearch(int[] inputArray, int searchValue)
        {

            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {                  
                    Node.Print("Искомый элемент под индексом: " + mid + "\n");
                    Node.Print("Аимптотическая сложность: O(log n)");
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }           
            return -1;
        }
    }
}
