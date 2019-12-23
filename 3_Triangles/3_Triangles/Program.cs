using System;

namespace _3_Triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedTriangleContainer triangles = UI.GetTriangles();
            triangles.OrderByDescending();
            UI.PrintTriangles(triangles);
            Console.ReadLine();
        }
    }
}
