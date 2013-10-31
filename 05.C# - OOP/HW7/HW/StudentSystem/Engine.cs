//Task04
//Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
//Override ToString() to display the information of a person and if age is not specified – to say so. 
//Write a program to test this functionality.

using System;
using System.Collections.Generic;

namespace StudentSystem
{
    class Engine
    {
        static void Main(string[] args)
        {
            //------
            //Task04
            //------

            List<Person> allPersons = new List<Person>()
            {
                new Person ("Ivan Petrov"),
                new Person ("Petar Ivanov", 35),
                new Person ("Dimitar Stoqnov"),
                new Person ("Stefan Kurtev", 71),
                new Person ("Atanas Georgiev", 56)
            };

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("The List of all persons is:");
            foreach (Person person in allPersons)
            {
                Console.WriteLine(person);
            }


            //-----------
            //Task06 Test
            //-----------

            BinarySearchTree<int> testBinarySearchTree = new BinarySearchTree<int>(10);
            testBinarySearchTree.AddElement(7);
            testBinarySearchTree.AddElement(17);
            testBinarySearchTree.AddElement(5);
            testBinarySearchTree.AddElement(15);
            testBinarySearchTree.AddElement(-5);
            testBinarySearchTree.AddElement(71);
            testBinarySearchTree.AddElement(70);
            testBinarySearchTree.AddElement(72);
            testBinarySearchTree.AddElement(9);

            Console.WriteLine("The current content of the binary search tree is:");
            Console.WriteLine();
            Console.WriteLine(testBinarySearchTree);

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Please enter one more integer in to the Binary Search tree:");

            bool correctValue = false;
            while (!correctValue)
            {
                try
                {
                    int newValue = int.Parse(Console.ReadLine());
                    if (testBinarySearchTree.AddElement(newValue))
                        correctValue = true;
                    else
                        Console.WriteLine("Already existing value! Please try again:");
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Incorrect value! Please try again:");
                }
            }

            Console.WriteLine();
            Console.WriteLine("The new content of the binary search tree is:");
            Console.WriteLine();
            Console.WriteLine(testBinarySearchTree);

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Please enter a value to be removed from Binary Search tree:");

            correctValue = false;
            while (!correctValue)
            {
                try
                {
                    int newValue = int.Parse(Console.ReadLine());
                    if (testBinarySearchTree.DeleteElement(newValue))
                        correctValue = true;
                    else
                        Console.WriteLine("Not existing value! Please try again:");
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Incorrect value! Please try again:");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please try again:");
                }
            }

            Console.WriteLine();
            Console.WriteLine("The new content of the binary search tree is:");
            Console.WriteLine();
            Console.WriteLine(testBinarySearchTree);

            Console.WriteLine();
            Console.WriteLine("Print the elements of the binary search tree using the enumerator:");
            Console.WriteLine();
            
            foreach (int nodeValue in testBinarySearchTree)
            {
                Console.WriteLine(nodeValue);
            }

            BinarySearchTree<int> newTestSearchTree = (BinarySearchTree<int>) testBinarySearchTree.Clone();

            Console.WriteLine();
            Console.WriteLine("The content of the cloned binary search tree is:");
            Console.WriteLine();
            Console.WriteLine(testBinarySearchTree);

            int lastValue = 0;
            IEnumerator<int> newTestTreeEnumerator = newTestSearchTree.GetEnumerator();
            bool deleteSuccess = false;
            while (newTestTreeEnumerator.MoveNext() && !deleteSuccess)
                try
                {
                    deleteSuccess = newTestSearchTree.DeleteElement(newTestTreeEnumerator.Current);
                }
                catch (Exception e){}
        
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("We have deleted one element from the cloned binary search tree.");
            Console.WriteLine("Now the cloned binary search tree looks like this:");
            Console.WriteLine();
            Console.WriteLine(newTestSearchTree);
            Console.WriteLine();
            Console.WriteLine("And the original binary search tree looks like this:");
            Console.WriteLine();
            Console.WriteLine(testBinarySearchTree);
        }
    }
}
