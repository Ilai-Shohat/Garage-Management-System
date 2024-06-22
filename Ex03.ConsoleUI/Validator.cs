using System;

namespace Ex03.ConsoleUI
{
    internal class Validator
    {
        public delegate bool TryParseDelegate<T>(string s, out T result);

        public static string InputValidatorGeneric<T>(Func<T, string, bool> i_ValidationFunc, T i_MaxValue)
        {
            string i_UserInput = Console.ReadLine();

            while (!i_ValidationFunc(i_MaxValue, i_UserInput))
            {
                i_UserInput = ConsoleRenderer.RenderRequest("The option you entered is invalid, try again please");
            }

            return i_UserInput;
        }

        public static bool IsNumberTypeAndInRange<T>(T i_HighestOptionNumber, string i_OptionToParse, TryParseDelegate<T> i_ParseMethod) where T : IComparable<T>
        {
            bool isValid = false;

            if (i_ParseMethod(i_OptionToParse, out T valueToValidate) &&
                valueToValidate.CompareTo(i_HighestOptionNumber) <= 0 &&
                valueToValidate.CompareTo(default) > 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
