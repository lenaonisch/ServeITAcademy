using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_Triangles
{
    public class TriangleContainer : IEnumerable<Triangle>
    {
        private const string TRIANGLE_IS_NULL = "Triangle is null. Nothing was added";
        private const string INDEX_OUT_OF_RANGE = "Invalid index";

        private List<Triangle> _triangles;

        public TriangleContainer(int count = 0)
        {
            _triangles = new List<Triangle>(count);
        }

        public TriangleContainer(IEnumerable<Triangle> triangles)
        {
            _triangles = new List<Triangle>();
            foreach (Triangle tr in triangles)
            {
                _triangles.Add((Triangle)tr.Clone());
            }
        }

        public Triangle this[int i]
        {
            get
            {
                if (i < _triangles.Count)
                {
                    return _triangles[i];
                }
                else
                {
                    throw new ArgumentOutOfRangeException(INDEX_OUT_OF_RANGE);
                }
            }
        }

        public void Add(Triangle triangle)
        {
            if (triangle != null)
            {
                _triangles.Add(triangle);
            }
            else
            {
                throw new ArgumentNullException("triangle", TRIANGLE_IS_NULL);
            }
        }

        #region IEnumerator

        public IEnumerator<Triangle> GetEnumerator()
        {
            return _triangles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _triangles.GetEnumerator();
        }

        #endregion

        public void OrderByDescending()
        {
            _triangles = _triangles.OrderByDescending(triangle => triangle.Square).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("============= Triangles list: ===============\n");
            foreach (Triangle t in _triangles)
            {
                sb.Append(t.ToString());
            }

            return sb.ToString();
        }
    }
}
