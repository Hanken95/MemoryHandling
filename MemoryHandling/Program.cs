using System;
using System.Diagnostics;

namespace MemoryHandling
{
    /*Svar:

    2.
    value type lagras på platsen de deklareras. Detta betyder att dessa kan finnas på heapen och i stacken.
    reference type kan bara lagras på heapen. Dessa kommer vi åt via en pointer. De ärver från Object.

    3.
    De är olika typer. De övre metoden hanterar value type som först sätter y till det värdet som x är men sedan ändrar y. Detta påvärkar
    inte x vilket betyder att x behåller sitt värde.
    I den andra metoden används object x och y. När y = x i detta fallet betyder det att både x och y pekar på samma object. Ändras något av
    dessa så ändras därför både. y.MyValue = 4 betyder alltså att även x.MyValue ändras till 4.



    */

    class Program
    {
        /// <summary>
        /// The main method, will handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                        * Extend the menu to include the recursive 
                        * and iterative exercises.
                        */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
                * Loop this method untill the user inputs something to exit to main menue.
                * Create a switch statement with cases '+' and '-'
                * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
                * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
                * In both cases, look at the count and capacity of the list
                * As a default case, tell them to use only + or -
                * Below you can see some inspirational code to begin working.
            */


            /*
                Frågor:
                2. När Count går över Capacity, alltså när något skall läggas till så att det skulle bli fler element i listan än Capacity
                3. Första ökningen är från 0 till 4. Sedan dubblas Capacity varje gång Count håller på att gå högra än Capacity
                4. Då blir effektiviteten och prestandan sämre
                5. Nej.
                6. Arrayer är bättre på att hämta innehållet medans listor är bättre på att lägga till och ta bort element.
                    Alltså listor för dynamiska lagringar där det skall plockas ut och in. Och arrayer för fasta lagringar där det är
                    viktigare att det går snabbare att komma åt varje värde i lagringen.



            */

            List<string> theList = new List<string>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter + before a word to add it to the list." +
                    "\nEnter - before a word to remove it from the list." +
                    "\nEnter c to clear the list" +
                    "\nOnly enter 0 to exit to the main menu.");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input[1..];
                Console.Clear();

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"{value} added to the list. Press any key to continue");
                        Console.ReadKey(true);
                        break;
                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"{value} removed to the list. Press any key to continue");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine($"{value} doesn't exist in the list. Press any key to continue");
                            Console.ReadKey(true);
                        }
                        break;
                    case 'c':
                        theList.Clear();
                        Console.WriteLine("List cleared. Press any key to continue");
                        Console.ReadKey(true);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("use only + or -");
                        Console.ReadKey(true);
                        break;

                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
                * Loop this method untill the user inputs something to exit to main menue.
                * Create a switch with cases to enqueue items or dequeue items
                * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            var queue = new Queue<string>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter + to queue a person last in the queue." +
                    "\nEnter - to dequeue the person that is first in line." +
                    "\nEnter v to view the queue" +
                    "\nEnter c to clear the queue" +
                    "\nOnly enter 0 to exit to the main menu.");

                char input = Console.ReadKey(true).KeyChar;
                Console.Clear();
                switch (input)
                {
                    case '+':
                        while (true)
                        {
                            Console.Write("Enter the name of the person: ");
                            string personQueued = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(personQueued))
                            {
                                Console.WriteLine("Incorrect input. Press any key to continue and try again");
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                            else
                            {
                                queue.Enqueue(personQueued);
                                Console.WriteLine($"{personQueued} added to the list. Press any key to continue");
                                Console.ReadKey(true);
                                break;
                            }
                        }
                        break;
                    case '-':
                        if (queue.TryPeek(out _))
                        {
                            var personDeQueued = queue.Dequeue();
                            Console.WriteLine($"{personDeQueued} dequeued. Press any key to continue");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine("No people in the queue. Press any key to continue");
                            Console.ReadKey(true);
                        }
                        break;
                    case 'v':
                        foreach (string person in queue)
                        {
                            Console.WriteLine(person);
                        }
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey(true);
                        break;
                    case 'c':
                        queue.Clear();
                        Console.WriteLine("Queue cleared. Press any key to continue");
                        Console.ReadKey(true);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("wrong input");
                        Console.ReadKey(true);
                        break;

                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
                * Loop this method until the user inputs something to exit to main menue.
                * Create a switch with cases to push or pop items
                * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            //Svar: 1. För då kommer den som lägger sig först i kön få komma fram sist.

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter r to use the ReverseTextmethod");
                Console.WriteLine("Enter 0 to go back to the main menu");

                char input = Console.ReadKey(true).KeyChar;
                Console.Clear();
                switch (input)
                {
                    case 'r':
                        ReverseText();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("wrong input");
                        Console.ReadKey(true);
                        break;

                }
            }

        }

        private static void ReverseText()
        {
            Console.Clear();
            Console.Write("Enter text: ");
            var text = Console.ReadLine();
            string reversedText = "";
            Stack<char> stack = new Stack<char>();
            foreach (var letter in text)
            {
                stack.Push(letter);
            }

            int stackCount = stack.Count;
            for (int i = 0; i < stackCount; i++)
            {
                reversedText += stack.Pop();
            }
            Console.Clear();
            Console.WriteLine("The reversed word is:");
            Console.WriteLine(reversedText);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(true);
        }

        static void CheckParanthesis(string stringToCheck = "")
        {
            /*
                * Use this method to check if the paranthesis in a string is Correct or incorrect.
                * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
                * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
                */

            Console.Clear();
            if (stringToCheck == "")
            {
                Console.WriteLine("Input string");
                stringToCheck = Console.ReadLine();
                Console.Clear();
            }
            var stack = new Stack<char>();

            foreach (var character in stringToCheck)
            {
                if (character == '(' || character == '{' || character == '[')
                {
                    stack.Push(character);
                }
                else if (character == ')')
                {
                    if (stack.Count < 1 || stack.Pop() != '(')
                    {
                        StringIsIncorrectMessage();
                        return;
                    }
                }
                else if (character == '}')
                {
                    if (stack.Count < 1 || stack.Pop() != '{')
                    {
                        StringIsIncorrectMessage();
                        return;
                    }
                }
                else if (character == ']')
                {
                    if (stack.Count < 1 || stack.Pop() != '[')
                    {
                        StringIsIncorrectMessage();
                        return;
                    }
                }
            }
            Console.WriteLine("String is correct");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void StringIsIncorrectMessage()
        {
            Console.WriteLine("String is incorrect");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
