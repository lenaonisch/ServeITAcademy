using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_Triangles
{
    class TriangleContainer : IEnumerable
    {
        private const string TRIANGLE_IS_NULL = "Triangle is null. Nothing was added";

        List<Triangle> Triangles;

        public TriangleContainer(int count = 0)
        {
            Triangles = new List<Triangle>(count);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(Triangle triangle)
        {
            if (triangle != null)
            {
                Triangles.Add(triangle);
            }
            else
            {
                throw new ArgumentNullException("triangle", TRIANGLE_IS_NULL);
            }
        }

        public void OrderByDescending()
        {
            Triangles = Triangles.OrderByDescending(triangle => triangle.Square).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("============= Triangles list: ===============\n");
            foreach (Triangle t in Triangles)
            {
                sb.Append(t.ToString());
            }

            return sb.ToString();
        }
    }
}
