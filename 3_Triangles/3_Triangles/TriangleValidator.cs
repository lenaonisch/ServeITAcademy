using FluentValidation;

namespace _3_Triangles
{
    class TriangleValidator : AbstractValidator<Triangle>
    {
        public TriangleValidator()
        {
            RuleFor(triangle => triangle.A).GreaterThan(0);
            RuleFor(triangle => triangle.B).GreaterThan(0);
            RuleFor(triangle => triangle.C).GreaterThan(0);
            RuleFor(triangle => triangle.A + triangle.B - triangle.C).GreaterThan(0);
        }
    }
}
