using Automata01.Core.Enums;

namespace Automata01.Core.Shared
{
    public static class StringExtensions
    {
        public static Direction ToDirection(this string input)
        {
            switch (input.Trim())
            {
                case "->":
                    return Direction.Right;
                case "<-":
                    return Direction.Left;
                default:
                    return Direction.None;
            }
        }
    }
}
