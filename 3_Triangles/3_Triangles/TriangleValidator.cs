using FluentValidation;

namespace _3_Triangles
{
    class TriangleValidator : AbstractValidator<Triangle>
    {
        public TriangleValidator()
        {
            RuleFor(triangle => triangle.SideA).GreaterThan(0);
            RuleFor(triangle => triangle.SideB).GreaterThan(0);
            RuleFor(triangle => triangle.SideC).GreaterThan(0);
            RuleFor(triangle => triangle.SideA + triangle.SideB - triangle.SideC).GreaterThan(0);
            RuleFor(triangle => triangle.SideA + triangle.SideC - triangle.SideB).GreaterThan(0);
            RuleFor(triangle => triangle.SideB + triangle.SideC - triangle.SideA).GreaterThan(0);
        }
    }
}
