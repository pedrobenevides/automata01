using System;
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

        public static int ToNextMove(this string input) => 
            input.IsFinal() ? Convert.ToInt16(input.Replace(',', ' ').Trim().Substring(0, 1))
            : Convert.ToInt16(input.Replace(',', ' ').Trim().Substring(1));

        public static bool IsFinal(this string input)
            => input.EndsWith("*");
    }
}
