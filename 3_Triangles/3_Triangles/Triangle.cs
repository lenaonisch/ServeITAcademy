using System;
using System.Text;

namespace _3_Triangles
{
    class Triangle : IComparable<Triangle>
    {
        private const string NO_TRIANGLE_ERROR = "Can't compare triangle with NULL";
        private double _square;
        private double _perimeter;

        public string Name { get; private set; }
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }
        
        public Triangle(string name, double sideA, double sideB, double sideC)
        {
            Name = name;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double Perimeter
        {
            get
            {
                _perimeter = SideA + SideB + SideC;
                return _perimeter;
            }
        }

        public double Square
        {
            get
            {
                double halfPerimeter = Perimeter / 2;

                _square = Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
                return _square;
            }
        }

        public int CompareTo(Triangle other)
        {
            if (other != null)
            {
                double secondSquare = other.Square;

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

            throw new ArgumentNullException(NO_TRIANGLE_ERROR);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[Triangle {0}]: {1:0.00}\n", Name, _square);

            return sb.ToString();
        }
    }
}
