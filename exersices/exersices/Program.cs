using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exersices
{
    internal class Program  
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 5, 8, 3, 8, 9, 34, 1, 234, 6, 8 };
            //CheckNumber();
            //CheckEvenOrAdd(2);
            //CheckPositiveOrNegative(5);
            //MultiplicationTable(2);
            //CaculateSelectedShape();
            //Console.ReadLine();
            //CaculateMultiplyTwoMatrices();
            //ReveserText();
            //CheckEqualNumberTryCatch();
            SelectionSort(array);
            ShowArray(array);
        }

        // function to check if 2 numbers are equal
        public static void CheckNumber()
        {
            int number1, number2;
            Console.WriteLine("Function to check if 2 numbers are equal");
            Console.WriteLine("_________________________________________");
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter the number 1: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number 2: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            if (number1 == number2)
            {
                Console.WriteLine("They are equal");
            }
            else
            {
                Console.WriteLine("They are not equal");
            }
        }

        // function to check a number is even number or odd number
        public static void CheckEvenOrAdd(int a)
        {
            if (a % 2 == 0)
            {
                Console.WriteLine(a + " " + "is a even number!");
                return;
            }
            Console.WriteLine(a + " " + "is a odd number!");
            return;
        }

        // function to check a number is positive number or negative number
        public static void CheckPositiveOrNegative(int a)
        {
            if (a < 0)
            {
                Console.WriteLine(a + " " + "is a negative number");
                return;
            }
            Console.WriteLine(a + " " + "is a positive number");
            return;
        }

        // function to multiplication table
        public static void MultiplicationTable(int a)
        {
            Console.WriteLine("The multiplication of " + a + ":");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("{0} * {1} = {2}", i, a, i * a);
            }
        }

        // function to select a shape to calculate area and perimeter
        public static void CaculateSelectedShape()
        {
            int choice, lenght, with, radius;
            double area, perimeter;

            Console.WriteLine("Number 1: caculate the area and the perimeter of the rectangle");
            Console.WriteLine("Number 2: caculate the area and the perimeter of the circle");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the length of the rectangle: ");
                    lenght = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the width of the rectangle: ");
                    with = Convert.ToInt32(Console.ReadLine());
                    area = with * lenght;
                    Console.Write("The area of the rectangle: " + area);
                    Console.Write("\n");
                    perimeter = (with + lenght) * 2;
                    Console.Write("The perimeter of the rectangle: " + perimeter);
                    break;
                case 2:
                    Console.Write("Enter the radius of the circle: ");
                    radius = Convert.ToInt32(Console.ReadLine());
                    area = radius * radius * 3.14;

                    Console.Write("The area of the circle: " + area);
                    Console.Write("\n");
                    perimeter = 2 * 3.14 * radius;
                    Console.Write("The perimeter of the circle: " + perimeter);
                    break;
            }


        }

        // function to reverse a text
        public static void ReveserText()
        {
            String text;

            do
            {
                Console.Write("Please enter your text: ");
                text = Console.ReadLine();
            }
            while (text == "");
            Console.Write("Your reveser text is: ");
            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(text[i]);
            }
        }

        //function to caculate multiply 2 matrices
        public static void CaculateMultiplyTwoMatrices()
        {
            int[,] array1 = new int[50, 50];
            int[,] array2 = new int[50, 50];
            int[,] array3 = new int[50, 50];
            int r1, r2, c1, c2, sum;
            Console.Write("Please enter the row of matrix 1: ");
            r1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Please enter the column of matrix 1: ");
            c1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();


            for (int i = 0; i < r1; i++)
            {
                for (int j = 0; j < c1; j++)
                {
                    Console.Write("Please enter the elements [{0},{1}]: ", i, j);
                    array1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Matrix 1:");
            for (int i = 0; i < r1; i++)
            {
                for (int j = 0; j < c1; j++)
                {
                    Console.Write("{0}\t", array1[i, j]);
                }

                Console.WriteLine();
            }

            Console.Write("Please enter the row of matrix 2: ");
            r2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Please enter the column of matrix 2: ");
            c2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();


            for (int i = 0; i < r2; i++)
            {
                for (int j = 0; j < c2; j++)
                {
                    Console.Write("Please enter the elements [{0},{1}]: ", i, j);
                    array2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Matrix 2:");
            for (int i = 0; i < r2; i++)
            {
                for (int j = 0; j < c2; j++)
                {
                    Console.Write("{0}\t", array2[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Multiplication of two matrices: ");
            if (c1 != r2)
            {
                Console.WriteLine("Cannot multiply two matrices, because the the row of matrix 1 {0} not equal the column of matri 2 {1} ", c1, r2);
            }
            else
            {
                for (int i = 0; i < r1; i++)
                {
                    for (int j = 0; j < c2; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < c1; k++)
                            sum = sum + array1[i, k] * array2[k, j];
                        array3[i, j] = sum;
                    }
                }
                for (int i = 0; i < r1; i++)
                {
                    for (int j = 0; j < c2; j++)
                    {
                        Console.Write("{0}\t", array3[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        // Try-catch
        public static void CheckEqualNumberTryCatch()
        {
            int number1, number2;
            try
            {

                Console.WriteLine("Function to check if 2 numbers are equal");
                Console.WriteLine("_________________________________________");
                Console.WriteLine("\n\n");
                Console.WriteLine("Enter the number 1: ");
                number1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the number 2: ");
                number2 = Convert.ToInt32(Console.ReadLine());

                if (number1 == number2)
                {
                    Console.WriteLine("They are equal");
                }
                else
                {
                    Console.WriteLine("They are not equal");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Oh no, This is error!");
            }
        }

        // Show an array
        public static void ShowArray(int[] a)
        {
            foreach (int o in a)
            {
                Console.Write(o);
                Console.Write("\t");
            }
        }

        // Selection sort
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }



    }



}




    
