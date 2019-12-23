using System;
using _3_Triangles;
using Xunit;


namespace UnitTests
{
    public class TrianglesUnitTests
    {
        private void CreateTriangle(string name, double sideA, double sideB, double sideC)
        {
            Triangle.CreateNewTriangle(name, sideA, sideB, sideC);
        }

        [Theory]
        [InlineData("triag1", 7, 1, 1)]
        [InlineData("triag2", 1, 7, 1)]
        [InlineData("triag3", 1, 1, 7)]
        public void FailedTriangleValidation(string name, double sideA, double sideB, double sideC)
        {
            Action action = () => Triangle.CreateNewTriangle(name, sideA, sideB, sideC);
            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [InlineData("triag1", 5.5, 5.0, 5.7)]
        public void PassedTriangleValidation(string name, double sideA, double sideB, double sideC)
        {
            Triangle triangle = Triangle.CreateNewTriangle(name, sideA, sideB, sideC);
            Assert.Equal(triangle.Perimeter, sideA + sideB + sideC);
            Assert.Equal(triangle.SideA, sideA);
            Assert.Equal(triangle.SideB, sideB);
            Assert.Equal(triangle.SideC, sideC);
        }

        [Fact]
        public void TriangleSort()
        {
            Triangle tr1 = Triangle.CreateNewTriangle("tr1", 3, 3, 3);
            Triangle tr2 = Triangle.CreateNewTriangle("tr2", 4, 4, 4);
            Triangle tr3 = Triangle.CreateNewTriangle("tr3", 5, 5, 5);
            Triangle[] triangles = new Triangle[] {
                tr1, tr2, tr3
            };

            SortedTriangleContainer triangleContainer = new SortedTriangleContainer(triangles);

            triangleContainer.OrderByDescending();

            Assert.Equal<Triangle>(triangleContainer[0], tr3);
            Assert.Equal<Triangle>(triangleContainer[1], tr2);
            Assert.Equal<Triangle>(triangleContainer[2], tr1);
        }
    }
}
