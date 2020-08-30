using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.C_Sharp_FullCourse
{
    [TestFixture]
    class all_basic
    {
        int num, num2;
        double dub;
        string str, str1;
        bool b;
        char c;

        [Test]
        public void dataType() 
            {
                /*************************************
                 * DataTypes
                 *************************************/
                num = 5;
                num2 = 10;
                dub = 1.4;
                str = "ball";
                str1 = "apple";
                b = true;
                c = 'd';

                Console.WriteLine(num + num2);
                Console.WriteLine(str.ToUpper());
                Console.WriteLine(str[0]);
            }
            /*************************************
             * Condational statement if and Else
             *************************************/
        [Test]
        public void CondationalIfAndElse()
        {
            if (num < num2)
            {
                Console.WriteLine("true one");
            }
            else if (str == str1)
            {
                Console.WriteLine("true two");
            }
            else
            {
                Console.WriteLine("none of the statement is true");
            }
        }

        [Test]
        public void forLoop() {
            /*************************************
             * for loop
             *************************************/
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=====================");
        }

        [Test]
        public void whileLoop() {
            /*************************************
           * While loop
           *************************************/
            int j = 0;
            while (j <= 5)
            {
                Console.WriteLine(j);
                j++;
            }
        }

        [Test]
        public void arraysType() {
            /******************************************
            * Array one-dimensional
            ******************************************/
            int[] arra = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arra[1]);

            String[] strArra = { "car", "truck", "Bike" };
            Console.WriteLine(strArra[0]);

            /******************************************
            * Array Two-dimensional
            ******************************************/
            int[,] arra1 = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 } };
            Console.WriteLine(arra1[0, 0]);
            Console.WriteLine(arra1[1, 0]);

            //Math
            Console.WriteLine(Math.Max(5, 10));
            Console.WriteLine(Math.Round(9.99));
        }
        [Test]
        public void switchCase()
        {
            /******************************************
            * Switch case
            ******************************************/
            int x = 2;
            switch (x)
            {
                case 1:
                    Console.WriteLine("case one");
                    break;
                case 2:
                    Console.WriteLine("case two");
                    break;
                default:
                    Console.WriteLine("None of them match");
                    break;

            }
            //Break and continue

            for (int l = 0; l < 3; l++)
            {
                if (l == 4)
                {
                    continue;
                }
                Console.WriteLine(l);
            }
        }
        [Test]
        public void methodCalling()
        {
            /******************************************
            * Method calling
            ******************************************/
            Console.WriteLine(car(10, 5));

            food();

            //CALLING MEHTOD OVERLOADING
            Console.WriteLine(PlusMethod(2, 3));
            Console.WriteLine(PlusMethod(1.2, 2.2));
            Console.ReadLine();
        }
    

        public static void food() 
        {
            Console.WriteLine("MOMO");
        }

        static int car(int a, int b)
        {
            Console.WriteLine("bmw is my fav car");
            return (a + b);
        }

        //METHOD OVERLOADING
        static int PlusMethod(int x, int y)
        {
            return x + y;
        }

        static double PlusMethod(double x, double y)
        {
            return x + y;
        }
    }

}

    

