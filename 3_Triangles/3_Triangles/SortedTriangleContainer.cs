using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3_Triangles
{
    public class SortedTriangleContainer : IEnumerable<Triangle>
    {
        private const string TRIANGLE_IS_NULL = "Triangle is null. Nothing was added";
        private const string INDEX_OUT_OF_RANGE = "Invalid index";

        private List<Triangle> _triangles;
        private bool _isSorted;

        public SortedTriangleContainer(int count = 0)
        {
            _triangles = new List<Triangle>(count);
            _isSorted = false;
        }

        public SortedTriangleContainer(IEnumerable<Triangle> triangles)
        {
            _triangles = new List<Triangle>();
            foreach (Triangle tr in triangles)
            {
                _triangles.Add((Triangle)tr.Clone());
            }
            _isSorted = false;
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
                _isSorted = false;
            }
            else
            {
                throw new ArgumentNullException("triangle", TRIANGLE_IS_NULL);
            }
        }

        #region IEnumerator

        public IEnumerator<Triangle> GetEnumerator()
        {
            if (!_isSorted)
            {
                _triangles.Sort((x, y) => -x.CompareTo(y));
                _isSorted = true;
            }
            return _triangles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        public void OrderByDescending()
        {
            if (!_isSorted)
            {
                _triangles.Sort((x, y) => -x.CompareTo(y));
                _isSorted = true;
            }
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
