using System;
using System.IO;

namespace HW_WK4_Problem4
{
    class Program
    {
        //Joe Buehring, Hayden Jones, Vince Cabahug
        /// <summary>    
        /// Creates and evalutes user response of a random 2 variable expression using +,-,/,* operands. Prints results.
        /// </summary>
        public static int GenerateFunction()
        {
            Random randNumGen = new Random();       //creates new random object
            double a = randNumGen.Next(1, 16);      //first random operand
            double b = randNumGen.Next(1, 16);      //second random operand
            int operation = randNumGen.Next(1, 5);  //random int to select which operator wil be used
            bool validity;                          //initializes variable to test for accuracy

            if (operation == 1)
            {
                Console.WriteLine("");
                Archiver($"What is the answer to this math problem? {a:N} + {b:N}", "\0");           //calls method to arhive and tell user to solve addition problem
                Console.WriteLine("");
                validity = ValidateResponse(Console.ReadLine()) == a + b;                                   //Calls ValidateResponse to ensure proper response, evaluates expression, and sets accuracy var
            }
            else if (operation == 2)
            {
                Console.WriteLine("");
                Archiver($"What is the answer to this math problem ? { a:N} * {b:N}", "\0");           //tells user to solve multiplication problem
                Console.WriteLine("");
                validity = ValidateResponse(Console.ReadLine()) == a * b;                                   //Calls ValidateResponse to ensure proper response, evaluates expression, and sets accuracy var
            }
            else if (operation == 3)
            {
                Console.WriteLine("");
                Archiver($"What is the answer to this math problem? {a:N} - {b:N}", "\0");           //calls method to arhive and tell user to solve addition problem
                Console.WriteLine("");
                validity = ValidateResponse(Console.ReadLine()) == a - b;                                   //Calls ValidateResponse to ensure proper response, evaluates expression, and sets accuracy var
            }
            else
            {
                Console.WriteLine("");
                Archiver($"What is the answer to this math problem? {a:N} / {b:N}", "\0");           //calls method to arhive and tell user to solve division problem
                Console.WriteLine("");
                validity = ValidateResponse(Console.ReadLine()) == Math.Round(a / b, 2);//Calls ValidateResponse to ensure proper response, evaluates expression, and sets accuracy var. Rounds to 2 digits
            }

            if (validity == true)
            {
                Console.WriteLine("");
                Archiver("Congratulations. That was the correct answer.", "\0");                                                    //if user responded with the correct response, print this line
                Console.WriteLine("");
                return 1;                                                                                   //increments counter in main
            }
            else
            {
                Console.WriteLine("");
                Archiver("Sorry. That was an incorrect response.", "\0");                                  //otherwise print this one
                Console.WriteLine("");
                return 0;                                                                                   //does not increment counter in main
            }
        }
        /// <summary>
        /// Verifies user response is a double, otherwise pushes for new response until it is a double, returns that double.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static double ValidateResponse(string response)
        {
            Archiver("\0", response);                                                           //Archives initial response, in case it doesnt go into the loop
            double answer;                                                                      //initialize response
            while (!double.TryParse(response, out answer))                                      //while response is not a double, continue loop
            {
                Console.WriteLine("");
                Archiver("Inappropriate response given the context; try again.", "\0");         //Tells user to try again
                Console.WriteLine("");
                response = Console.ReadLine();                                                  //sets loop test variable to be the new response to test
                Archiver("\0", response);
            }
            return answer;                                                                      //return user supplied double
        }
        /// <summary>
        /// Handles writing to file and console
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="outputString"></param>
        public static void Archiver(string outputString, string inputString)
        {
            StreamWriter fileName = new StreamWriter(@"C:\Users\josep\source\repos\HW_WK4_Problem04\HW_WK4_Problem04\Output.txt", true);                          //Creates file into which console activity will be dumped

            Console.WriteLine(outputString);                                                        //write to console my message

            if (outputString != "\0")                                                                //this condition removes extra lines when userinput is added, due to argument order
                fileName.WriteLine("Output: {0}", outputString);                                     //write to file my message, with an index prefix to parse later if needed

            if (inputString != "\0")                                                                 //this condition removes extra lines when userinput is added, due to argument order
                fileName.WriteLine("Input : {0}", inputString);                                     //write to file their response, with an index prefix to parse later if needed

            fileName.Close();                                                                       //all things must come to an end
        }
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This program will create math expressions to solve and store the archived answers in a text document");
            Console.WriteLine("====================================================================================================");
            Console.WriteLine(@"                      _   _                                  _    
                      | | (_)                                | |   
  __ _ _   _  ___  ___| |_ _  ___  _ __  _ __ ___   __ _ _ __| | __
 / _` | | | |/ _ \/ __| __| |/ _ \| '_ \| '_ ` _ \ / _` | '__| |/ /
| (_| | |_| |  __/\__ \ |_| | (_) | | | | | | | | | (_| | |  |   < 
 \__, |\__,_|\___||___/\__|_|\___/|_| |_|_| |_| |_|\__,_|_|  |_|\_\
    | |                                                            
    |_|                                                            
");
          
            Console.Title = "This program will create an expression to be solved and archive everything in a text document to be perused at your convenience.";  //Superfluous exposition

            int i = 0;                                                                              //Initializes while loop counter, this is why for loops are better. sue me
            int counter = 0;                                                                        //Initiaizes correct response counter

            while (i++ < 20)                                                                        //calls expression 20 times
                counter = counter + GenerateFunction();                                             //calls function and uses return vaue to increment counter

            Archiver($"You got this many correct answers {counter} / 20", "\0");                                     //calls method to arhive and print number of correct respones
        }
    }
}
