using System;
using System.Text;

namespace _3_Triangles
{
    class Triangle : IComparable
    {
        private const string NOT_TRIANGLE_ERROR = "Can't compare triangle with NOT a triangle";
        private double _square;
        private double _perimeter;

        public string Name { get; private set; }
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        
        public Triangle(string name, double sideA, double sideB, double sideC)
        {
            Name = name;
            A = sideA;
            B = sideB;
            C = sideC;
        }

        public double Perimeter
        {
            get
            {
                _perimeter = A + B + C;
                return _perimeter;
            }
        }

        public double Square
        {
            get
            {
                double halfPerimeter = Perimeter / 2;

                _square = Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
                return _square;
            }
        }

        int IComparable.CompareTo(object obj)
        {
            Triangle secondTriangle = obj as Triangle;
            if (secondTriangle != null)
            {
                double secondSquare = secondTriangle.Square;
                if (_square < secondSquare)
                {
                    return -1;
                }
                else 
                {
                    if (_square > secondSquare)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            throw new ArgumentException(NOT_TRIANGLE_ERROR);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[Triangle {0}]: {1:0.00}\n", Name, _square);

            return sb.ToString();
        }
    }
}
