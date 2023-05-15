using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using static TestWorld.TestWorld;

namespace TestWorld
{
    public class TroubleSortTests
    {
        // Return true if the array is sorted in non-decreasing order, else false
        private static bool IsSorted(IReadOnlyList<int> array)
        {
            for (var i = 0; i < array.Count - 1; ++i)
                if (array[i] > array[i + 1])
                    return false;
            return true;
        }


        [Test]
        public void EmptySort()
        {
            int[] array = { };
            TroubleSort(array);
            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }


        [Test]
        public void EasySort()
        {
            int[] array = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            TroubleSort(array);

            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }


        [Test]
        public void EasySort2()
        {
            int[] array = {8, 7, 6, 5, 4, 3, 2, 1, 0};
            TroubleSort(array);

            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }


        [Test]
        public void EasySort3()
        {
            int[] array = {1, 2, 3, 4, 4, 3, 2, 1, 0};
            TroubleSort(array);
            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }


        [Test]
        public void MediumSort()
        {
            int[] array = {1, 2, 3, 4, 4, 3, 2, 1, 0};
            TroubleSort(array);
            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }

        [Test]
        public void MediumSort2()
        {
            int[] array = {0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0, 1};
            TroubleSort(array);
            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }

        [Test]
        public void HardSort()
        {
            int[] array =
            {
                12, 31, 49, 10, 19, 3, 17, 27, 43, 28, 32, 35, 3, 18, 43, 39, 7, 16, 19,
                26, 49, 13, 25, 14, 22, 26, 39, 22, 27, 2
            };

            TroubleSort(array);
            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }

        [Test]
        public void HardSort2()
        {
            int[] array =
            {
                44, 4, 13, 33, 15, 49, 7, 39, 48, 28, 1, 43, 1, 3, 5, 20, 7, 25, 21, 29, 10,
                30, 42, 12, 14, 40, 45, 31, 49, 1
            };

            TroubleSort(array);
            // WHEN
            bool res = IsSorted(array);

            // THEN
            Assert.IsTrue(res);
        }
    }

    public class BinarySearchTests
    {
        [Test]
        public void EasyBinarySearch()
        {
            int[] array = {0, 1, 2, 3, 4, 5};
            int pos = BinarySearch(array, 5);
            Assert.AreEqual(5, pos);
        }

        [Test]
        public void EmptyBinarySearch()
        {
            int[] array = { };
            int pos = BinarySearch(array, 20);
            Assert.AreEqual(0, pos);
        }

        [Test]
        public void MediumBinarySearch()
        {
            int[] array = new int[18];
            for (int i = 0; i < 18; i++)
            {
                array[i] = i;
            }
            int pos = BinarySearch(array, 8);
            Assert.AreEqual(8, pos);
        }

        [Test]
        public void MediumBinarySearch2()
        {
            int[] array = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 20};
            int pos = BinarySearch(array, 20);
            Assert.AreEqual(18, pos);
        }
        
        [Test]
        public void HardBinarySearch()
        {

            int[] array = new int[50];
            for (int i = 0; i < 50; i++)
            {
                array[i] = i;
            }
            
            int pos = BinarySearch(array, 32);
            Assert.AreEqual(32, pos);
        }

        [Test]
        public void HardestOneBinarySearch()
        {
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = i;
            }

            int pos = BinarySearch(array, 110);
            Assert.AreEqual(100, pos);
        }
    }

    public class FizzBuzzTests
    {
        [Test]
        public void EqualZero()
        {
            string str = PrintFizz(0);
            Assert.AreEqual("", str);
        }
        
        [Test]
        public void SmallNumber()
        {
            string str = PrintFizz(7);
            Assert.AreEqual("7", str);
        }
        
        [Test]
        public void FizzBuzz()
        {
            string str = PrintFizz(30);
            Assert.AreEqual("Fizz Buzz", str);
        }
        
        [Test]
        public void Buzz()
        {
            string str = PrintFizz(50);
            Assert.AreEqual("Buzz", str);
        }
        
        [Test]
        public void Fizz()
        {
            string str = PrintFizz(81);
            Assert.AreEqual("Fizz", str);
        }
        
        [Test]
        public void MediumNumber()
        {
            string str = PrintFizz(131);
            Assert.AreEqual("131", str);
        }
        
        [Test]
        public void BigNumber()
        {
            string str = PrintFizz(1097);
            Assert.AreEqual("1097", str);
        }

        [Test]
        public void ExtremeNumber()
        {
            string str = PrintFizz(19997);
            Assert.AreEqual("19997", str);
        }
    }

    public class TidysTests
    {
        [Test]
        public void Easy1()
        {
            Assert.AreEqual(5, TidyNumber(5));
        }
        
        
        [Test]
        public void Easy2()
        {
            Assert.AreEqual(19, TidyNumber(21));
        }
        
        
        [Test]
        public void Medium1()
        {
            Assert.AreEqual(179, TidyNumber(183));
        }
        
        [Test]
        public void Medium2()
        {
            Assert.AreEqual(499, TidyNumber(538));
        }
        
        [Test]
        public void Hard1()
        {
            Assert.AreEqual(999, TidyNumber(1057));
        }
        
        [Test]
        public void Hard2()
        {
            Assert.AreEqual(1169, TidyNumber(1176));
        }
    }
}
