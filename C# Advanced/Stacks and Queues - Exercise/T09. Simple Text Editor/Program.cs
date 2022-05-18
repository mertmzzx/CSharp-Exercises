using System;
using System.Collections.Generic;
using System.Text;

namespace T09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //брой на командите

            StringBuilder text = new StringBuilder(); //празен текст
            Stack<string> textHistory = new Stack<string>();

            for (int i = 1; i <= n; i++)
            {
                string command = Console.ReadLine();

                if (command.StartsWith("1"))
                {
                    textHistory.Push(text.ToString());
                    //•   "1 {someString}".Split() -> ["1", "{someString}"]
                    string textForAdd = command.Split()[1];
                    text.Append(textForAdd);
                }
                else if (command.StartsWith("2"))
                {
                    textHistory.Push(text.ToString());
                    //•   "2 8".Split() -> ["2", "8"]
                    int count = int.Parse(command.Split()[1]);
                    //"Pesho" -> 2
                    text.Remove(text.Length - count, count);
                }
                else if (command.StartsWith("3"))
                {
                    //•   "3 {index}".Split() -> ["3", "{index}"]
                    int index = int.Parse(command.Split()[1]); //поредния номер на буквата
                    Console.WriteLine(text[index - 1]);
                }
                else if (command.StartsWith("4"))
                {
                    //•   "4" - undoes the last not undone command of type 1 or 2 and returns the text to the state before that operation.
                    text = new StringBuilder(textHistory.Pop());
                }
            }
        }
    }
}
