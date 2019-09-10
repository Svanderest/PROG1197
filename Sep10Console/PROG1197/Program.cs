using System;

namespace PROG1197
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get text form user
            string myString;
            do
            {
                Console.WriteLine("Please enter a word or type \"Exit\" to quit");
                myString = Console.ReadLine();
            } while (myString.Length == 0);

            //Check for exit
            if(myString.ToLower() != "exit")
            {
                //Get number from user
                int myIndex = -1;
                do
                {
                    Console.WriteLine(string.Format("Please enter a position number in the text: {0}",myString));
                } while (!int.TryParse(Console.ReadLine(), out myIndex) || myIndex >= myString.Length);

                //Return result
                Console.WriteLine(string.Format("The character at position {0} is {1}", new object[] { myIndex, myString[myIndex] }));
            }            
        }
    }
}
