using System;
using NUnit.Framework;
using static TestLand.TestLand;

namespace TestLand
{
    public class TestPalindrome
    {
        [Test]
        public void PalindromeEmpty()
        {
            // GIVEN
            string str = "";

            // WHEN
            bool result = Palindrome(str);
            
            // THEN
            Assert.IsTrue(result);
        }
        
        [Test]
        public void PalindromeSpace()
        {
            // GIVEN
            string str = "                      ";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }
        
        [Test]
        public void PalindromeEasy()
        {
            // GIVEN
            string str = "aa";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }

        [Test]
        public void PalindromeEasy2()
        {
            // GIVEN
            string str = "ACDC";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsFalse(result);
        }
        
        [Test]
        public void PalindromeLeadingSpace()
        {
            // GIVEN
            string str = "             lol";

            // WHEN
            bool result = Palindrome(str);

            //THEN
            Assert.IsTrue(result);
        }
        
        [Test]
        public void PalindromeTrailingSpace()
        {
            // GIVEN
            string str = "kayak                 ";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }

        [Test]
        public void PalindromeSpecialChar()
        {
            // GIVEN
            string str = "1 + 1 = ?";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }
        
        [Test]
        public void PalindromeSpecialChar2()
        {
            // GIVEN
            string str = "Léon a sucé ses écus à Nöel";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsFalse(result);
        }
        
        [Test]
        public void PalindromeHard()
        {
            // GIVEN
            string str = "Leon a suce ses ecus a Noel";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }
        
        [Test]
        public void PalindromeHard2()
        {
            // GIVEN
            string str = "P+ai^^^^lôlot(e)24 = 42    eto lélia!  P*##    ";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }

        [Test]
        public void PalindromeOneChar()
        {
            // GIVEN
            string str = "e";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }
        
        [Test]
        public void PalindromeOneChar2()
        {
            // GIVEN
            string str = "            e     +_éééé";

            // WHEN
            bool result = Palindrome(str);

            // THEN
            Assert.IsTrue(result);
        }
    }

    public class TestClimbingStairs
    {
        [Test]
        public void ClimbingStairsEmpty()
        {
            // GIVEN
            uint[] costs = {};
            
            // WHEN
            uint res = ClimbingStairs(costs);
            
            // THEN
            Assert.AreEqual(0, res);
        }
        
        [Test]
        public void ClimbingStairsOneStep()
        {
            // GIVEN
            uint[] costs = { 42 };
            
            // WHEN
            uint res = ClimbingStairs(costs);
            
            // THEN
            Assert.AreEqual(42, res);
        }
        
        [Test]
        public void ClimbingStairsEasy()
        {
            // GIVEN
            uint[] costs = {1, 2};
            
            // WHEN
            uint res = ClimbingStairs(costs);
            
            // THEN
            Assert.AreEqual(2, res);
        }
        
        [Test]
        public void ClimbingStairsMedium()
        {
            // GIVEN
            uint[] costs = {18, 2, 1};
            
            // WHEN
            uint res = ClimbingStairs(costs);
            
            // THEN
            Assert.AreEqual(3, res);
        }
        
        [Test]
        public void ClimbingStairsHard()
        {
            // GIVEN
            uint[] costs = {18, 2, 24, 1, 1, 42, 2, 13, 12, 11, 4, 6};
            
            // WHEN
            uint res = ClimbingStairs(costs);
            
            // THEN
            Assert.AreEqual(28, res);
        }
        
        [Test]
        public void ClimbingStairsHard2()
        {
            // GIVEN
            uint[] costs = {18, 2, 24, 1, 1, 42, 2, 13, 12, 11, 4, 6, 46, 2, 20, 9999999, 1, 1, 50, 500000, 12, 3};
            
            // WHEN
            uint res = ClimbingStairs(costs);
            
            // THEN
            Assert.AreEqual(116, res);
        }
    }

    public class TestWonderlandProblem
    {
        [Test]
        public void WonderlandProblemEmpty()
        {
            // GIVEN
            int size = 10;
            Person[] persons = new Person[0];

            // WHEN
            Tuple<int, int> res = WonderlandProblem(size, persons);
            
            // THEN
            Assert.AreEqual(new Tuple<int, int>(0, 0), res);
        }
        
        [Test]
        public void WonderlandProblemEasy()
        {
            // GIVEN
            int size = 10;
            Person[] persons = new Person[1];
            persons[0] = new Person(5, 5, Person.Direction.NORTH);

            // WHEN
            Tuple<int, int> res = WonderlandProblem(size, persons);
            
            // THEN
            Assert.AreEqual(new Tuple<int, int>(0, 5), res);
        }
        
        [Test]
        public void WonderlandProblemMedium()
        {
            // GIVEN
            int size = 10;
            Person[] persons = new Person[2];
            persons[0] = new Person(5, 5, Person.Direction.NORTH);
            persons[1] = new Person(3, 3, Person.Direction.EAST);

            // WHEN
            Tuple<int, int> res = WonderlandProblem(size, persons);
            
            // THEN
            Assert.AreEqual(new Tuple<int, int>(3, 5), res);
        }
        
        [Test]
        public void WonderlandProblemMedium2()
        {
            // GIVEN
            int size = 10;
            Person[] persons = new Person[2];
            persons[0] = new Person(5, 5, Person.Direction.NORTH);
            persons[1] = new Person(2, 3, Person.Direction.WEST);

            // WHEN
            Tuple<int, int> res = WonderlandProblem(size, persons);
            
            // THEN
            Assert.AreEqual(new Tuple<int, int>(0, 5), res);
        }
        
        [Test]
        public void WonderlandProblemHard()
        {
            // GIVEN
            int size = 10;
            Person[] persons = new Person[8];
            persons[0] = new Person(0, 2, Person.Direction.EAST);
            persons[1] = new Person(0, 6, Person.Direction.EAST);
            persons[2] = new Person(2, 3, Person.Direction.EAST);
            persons[3] = new Person(2, 7, Person.Direction.WEST);
            persons[4] = new Person(4, 8, Person.Direction.WEST);
            persons[5] = new Person(5, 5, Person.Direction.NORTH);
            persons[6] = new Person(8, 6, Person.Direction.WEST);
            persons[7] = new Person(9, 6, Person.Direction.NORTH);

            // WHEN
            Tuple<int, int> res = WonderlandProblem(size, persons);
            
            // THEN
            Assert.AreEqual(new Tuple<int, int>(2, 5), res);
        }
        
        [Test]
        public void WonderlandProblemHard2()
        {
            // GIVEN
            int size = 10;
            Person[] persons = new Person[8];
            persons[0] = new Person(0, 0, Person.Direction.WEST);
            persons[1] = new Person(1, 4, Person.Direction.SOUTH);
            persons[2] = new Person(2, 7, Person.Direction.WEST);
            persons[3] = new Person(5, 1, Person.Direction.EAST);
            persons[4] = new Person(7, 6, Person.Direction.NORTH);
            persons[5] = new Person(8, 8, Person.Direction.NORTH);
            persons[6] = new Person(9, 3, Person.Direction.EAST);
            persons[7] = new Person(9, 6, Person.Direction.NORTH);

            // WHEN
            Tuple<int, int> res = WonderlandProblem(size, persons);
            
            // THEN
            Assert.AreEqual(new Tuple<int, int>(2, 6), res);
        }
    }
}