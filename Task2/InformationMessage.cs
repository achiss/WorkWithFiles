using System;

namespace Task2
{

    public class InformationMessage
    {
        public static void ValueMessage(in string message) =>
            Console.WriteLine($"[INFO] You have problems with the data of message \n{message}, reapet the input.");

        public static void ErrorMessage() => Console.WriteLine($"[ERROR] Something wrong with app. Please, close the app.");
    }

}