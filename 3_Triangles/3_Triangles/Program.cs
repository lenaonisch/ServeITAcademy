using System;

namespace _3_Triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleContainer triangles = UI.GetTriangles();
            triangles.OrderByDescending();
            UI.PrintTriangles(triangles);
            Console.ReadLine();
        }
    }
}
