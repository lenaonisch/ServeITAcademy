using FluentValidation;

namespace _1_Chess
{
    class UI
    {
        public static bool ValidateArgs(string[] args, out uint height, out uint width)
        {
            width = 0;
            height = 0;
            return (uint.TryParse(args[0], out height) && uint.TryParse(args[1], out width));
        }
    }
}
