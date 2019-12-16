using System;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace _3_Triangles
{
    class UI
    {
        const int NUMBER_OF_PARAMETERS = 4;
        
        const string INVALID_DOUBLE = "Can't convert some string into floating point number!";

        public static Triangle GetNewTriangle()
        {
            string userInput;
            List<string> dividedInput;
            double A;
            double B;
            double C;
            int numberOfParameters = 4;
            Triangle result = null;

            Console.WriteLine("Enter triangle in format: <name>, <side 1>, <side 2>, <side 3>");

            do
            {
                userInput = Console.ReadLine();
                dividedInput = userInput.Split(',').ToList();
                dividedInput = dividedInput.Select(str => str.Trim(' ', '\t')).ToList();
            } while (dividedInput.Count() < numberOfParameters);

            if (double.TryParse(dividedInput[1], out A)
                && double.TryParse(dividedInput[2], out B)
                && double.TryParse(dividedInput[3], out C))
            {
                try
                {
                    result = Triangle.CreateNewTriangle(dividedInput[0], A, B, C);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine(INVALID_DOUBLE);
            }

            return result;
        }

        public static TriangleContainer GetTriangles()
        {
            string userAnswer = "y";
            TriangleContainer triangles = new TriangleContainer();

            while (userAnswer == "y" || userAnswer == "yes")
            {
                Triangle currentTriangle = GetNewTriangle();
                if (currentTriangle != null)
                {
                    triangles.Add(currentTriangle);
                }
                Console.WriteLine("Do you want to continue (y/yes)?");
                userAnswer = Console.ReadLine().ToLower();
            }

            return triangles;
        }

        public static void PrintTriangles(TriangleContainer triangles)
        {
            Console.WriteLine(triangles.ToString());
        }
    }
}
