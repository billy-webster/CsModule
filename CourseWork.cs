using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace FinalProduct
{
    class program
    {
        static string[,] StudentDatabase = new string[250, 7]; //Creates an empty 2d array at the start for option B of the menu. Fixed size of 250x7.
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green; //Changes text color to green
            Thread.Sleep(1000);
            Console.WriteLine(" __      __       .__                               ");
            Console.WriteLine("/  \\    /  \\ ____ |  |   ____  ____   _____   ____ ");
            Console.WriteLine("\\   \\/\\/   // __ \\|  | _/ ___\\/  _ \\ /     \\_/ __ \\");           //Custom Ascii text using website:https://patorjk.com/software/taag/#p=display&f=Big&t=Menu
            Console.WriteLine("  \\__/\\  /  \\___  >____/\\___  >____/|__|_|  /\\___  >");
            Console.WriteLine("       \\/       \\/          \\/            \\/     \\/");
            Thread.Sleep(2000); //Delays the rest of the page for 2000 milliseconds or 2 seconds
            Console.Clear(); //Clears the welcome screen before loading the menu
            
            Menu(); //Calls the menu function
        }
        static void Menu()
        {
            Console.Clear();
            string UserInput = " ";
            string title = @"
 __  __                  
|  \/  |                 
| \  / | ___ _ __  _   _ 
| |\/| |/ _ \ '_ \| | | |
| |  | |  __/ | | | |_| |
|_|  |_|\___|_| |_|\__,_|                                                  
";

            
            do //do while, to loop the menu without the use of recursion
            {

                Console.WriteLine(title);    
                Console.WriteLine("");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("====================================");
                Console.WriteLine("a) Trinary Converter");  //Outputs a basic menu system.
                Console.WriteLine("b) School Roster");
                Console.WriteLine("c) ISBN Verifier");
                Console.WriteLine("q) End the program");

                string OptionInput = Console.ReadLine();
                if (OptionInput.Length != 1)
                {
                    Console.WriteLine("Enter a single character"); //Error handling for if they enter an invalid input
                    Thread.Sleep(2000); 
                    Console.Clear();
                    UserInput = "";
                }
                else
                {
                    UserInput = OptionInput.ToLower(); //Converts the input to a lower character
                }

                if (UserInput == "a")
                {
                    TrinaryConverter();
                }
                else if (UserInput == "b")  //calls the corresponding function based on the user input
                {
                    SchoolRoster();
                }
                else if (UserInput == "c")
                {
                    ISBNVerifier();
                }
                else if (UserInput == "q")
                {
                    Console.WriteLine("Exiting Menu");
                    Thread.Sleep(2000);                     //If the user wishes to exit, the program leaves the while loop, and exits the function/program.
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please Use Valid Input");
                    Thread.Sleep(2000); 
                    Console.Clear();            //Error handling for wrong input type

                }


            } while (UserInput != "a" && UserInput != "b" && UserInput != "c" && UserInput != "q"); //Loops while user doesnt input valid statement


        }
        static void TrinaryConverter() //Trinary function for option 'a'
        {
            int TrinaryNumber = 0;

            Console.WriteLine("Please Enter Trinary Number:");
            try
            {
                TrinaryNumber = int.Parse(Console.ReadLine()); //Converts the user input to an integer variable
                if (CheckValidity(TrinaryNumber.ToString())) //.ToString temporarliy converts the int to string, it is then used as a parameter for the function being called.
                {
                    Console.WriteLine("Please enter a valid format for the trinary number");
                    Console.WriteLine("Output: 0"); //Runs through the function which will either return true or false, and if true gives this error message. 
                }
                else
                {
                    int ConvertedDecimal = TrinaryToDecimal(TrinaryNumber.ToString());
                    Console.WriteLine("Decimal Equivalent: {0}", ConvertedDecimal); //If its found to be a valid input type, it then uses the variable as parameters for the converter function, and displays the output.
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid format for the trinary number");
                Console.WriteLine("Output: {0}", TrinaryNumber); //Catches any other errors that might happen in the above block of code.
            }
            Thread.Sleep(3000);
            Menu();
        }

        static int TrinaryToDecimal(string InputNumber)  //Takes in variable for parameters in order to convert it to Decimal format.
        {
            int DecimalConverted = 0;
            char[] ValuesArray = new char[InputNumber.Length]; //Creates a character array with the fixed length of the size of the user input string.
            for (int i = 0; i < InputNumber.Length; i++) //For loop to copy the input string into the array.
            {
                ValuesArray[i] = InputNumber[i];
            }
            Array.Reverse(ValuesArray); //Reverses the array for the process below
            for (int power = 0; power < ValuesArray.Length; power++)
            {
                DecimalConverted += (int)Math.Pow(3, power) * int.Parse(ValuesArray[power].ToString()); //For loop for every character, runs the converting formula for trinary to decimal.
            }
            return DecimalConverted; //Returns the output as an integer variable. This is also seen at "static int".
        }

        static bool CheckValidity(string InputNumber) //Small function to check the validity of the input
        {
            string[] InvalidInputs = { "4", "5", "6", "7", "8", "9" }; //Trinary only allows 0,1,2 and 3.
            foreach (string i in InvalidInputs) //Searches the user input for the invalid input types for every character in the string.
            {
                if (InputNumber.Contains(i)) //If the variable contains the forbidden inputs, return true meaning it was found invalid.
                {
                    return true;
                }
            }
            return false; //Returns false if its invalid.
        }

        static void SchoolRoster() //Function for menu system of School Roster
        {
            bool loop = true;
            while (loop) //While loop to repeat the menu function without recursion.
            {
                Console.Clear();

                Console.WriteLine("*******************************");
                Console.WriteLine("School Roster System");
                Console.WriteLine("Welcome, would you like to:");
                Console.WriteLine("A) Add students to forms");                  //Basic menu system for school roster
                Console.WriteLine("B) Check which form a Student is in");
                Console.WriteLine("C) View list of students in a form");
                Console.WriteLine("*******************************");

                string Input_Request = Console.ReadLine();
                if (Input_Request.ToUpper() == "A")             //.ToUpper() makes the user input all upper case.
                {
                    AddStudents();
                }
                else if (Input_Request.ToUpper() == "B")
                {
                    CheckStudents();                            //Takes user to requested function depending on their result
                }
                else if (Input_Request.ToUpper() == "C")
                {
                    ViewForms();
                }
                else
                {
                    Console.WriteLine("Please Enter a valid input format");             //Error handling for if they input the wrong type.


                }
                Console.WriteLine("Would you like to check anything else:");
                string RepeatFunction = Console.ReadLine();
                if (RepeatFunction.ToUpper() != "Y")                                //Asks the user if they want to repeat any functions, then breaks the while loop if they dont.
                {
                    loop = false;

                }
            }
            Thread.Sleep(3000);
            Menu();             //Calls back to the menu if they dont want to repeat.

        }
        static void AddStudents() //Function for option A
        {
            Console.WriteLine("Enter the name of the student followed by the form,");
            Console.WriteLine("Using the format Student,Form:");
            string InputData = Console.ReadLine();
            try                                 //Try catch for backup error handling in case any random error occurs.
            {
                string[] Split = InputData.Split(',');          //Splits the data into two sections by the comma in the input.
                if (Split.Length != 2)
                {
                    Console.WriteLine("Include only two inputs"); //If there are more than two variables that have been split, display custom error message.

                }
                else
                {
                    string name = Split[0];                 //Stores the first part split in a variable named 'name'.
                    int form = int.Parse(Split[1]);         //Stores the second part in an integer variable named 'form'.
                    int emptylocation = -1;
                    for (int i = 0; i < StudentDatabase.GetLength(0); i++) //Repeats the loop for as many times as there are items in the array.
                    {
                        if (string.IsNullOrEmpty(StudentDatabase[i, form]))  //Loop searches for the first empty and available space in the array.
                        {
                            emptylocation = i;                              //if one has been found, change the empty location variable. This is for multiple statements later
                            break;
                        }
                    }
                    if (emptylocation != -1)
                    {
                        StudentDatabase[emptylocation, form] = name;        //If an empty location has been found, empty location variable will store where this is. This variable will be used to insert the user data into the array.
                        Console.WriteLine("{0} has been added to form {1}", name, form); //Use of formatting to output variable names in the printed string.
                    }
                    else
                    {
                        Console.WriteLine("Form has no  space left"); //If empty location hasnt been changed, then there is no empty space therefore dont add anything to the form.

                    }
                }
            }
            catch
            {
                Console.WriteLine("Please Enter valid format");         //Backup error handling message.
            }


        }
        static void CheckStudents() //Option b in the student menu
        {
            Console.WriteLine("Enter the name of a student to see which form they are in:");
            Console.WriteLine("Student Name:");
            string StudentName = Console.ReadLine();

            bool found = false;                         //Store found as false for the following loops which will search for the data in the array, if found this will change to true.
            for (int i = 0; i < StudentDatabase.GetLength(0); i++) //Get Length(0) returns the length of the first elements in the array. 
            {
                for (int j = 0; j < StudentDatabase.GetLength(1); j++)      //Nested for loop is required to search both elements in the 2D array.
                {
                    if (StudentDatabase[i, j] == StudentName)           //If the user input matches the values in the array:
                    {
                        Console.WriteLine("{0} is in form {1}", StudentName, j);            //Format custom message containing the location it was found in.
                        found = true;                       //Used in order to break from the loop
                        break;                              //Breaks out of second loop
                    }
                }
                if (found)
                {
                    break;                      //Breaks out of first for loop.
                }
            }

            if (!found)
            {
                Console.WriteLine("Student not found in any form.");            //If nothing is found in the whole array, found remains false and will output custom message as a response.
            }


        }
        static void ViewForms()                             //Function for option C in the school menu
        {
            Console.WriteLine("Enter the number of the form you wish to view:");
            try                                                              //Try catch used for error handling.
            {
                int Form_Number = int.Parse(Console.ReadLine());
                string list = null;                                          //Creates empty string that will be manipulated to store the data later.
                for (int i = 0; i < StudentDatabase.GetLength(0); i++)          //Searches the array by the first element which is the name.
                {
                    if (!string.IsNullOrEmpty(StudentDatabase[i, Form_Number]))    //If the elements in the form are not empty, concatenate onto end of string.
                    {

                        list += StudentDatabase[i, Form_Number];
                        list += ", ";                               //Concatenates onto empty string, followed by a comma for easy readbility/format.
                    }
                }
                list = list.Remove(list.Length - 2);                //Removes the last 2 characters off the string which are the comma and empty space. This is because there is no need for an extra comma at the end of the statement
                Console.WriteLine("The list of students in form {0} are:", Form_Number);
                Console.WriteLine(list);                            //Outputs required data.
            }
            catch
            {
                Console.WriteLine("Please type in a correct number for a form");    //Catches any errors during process.
            }


        }

        static void ISBNVerifier()              //Function for the ISBN validator option.
        {

            bool loop = true;               //Starts the loop as true.
            while (loop)                    //While loop to repeat as many times as the user wants
            {
                Console.Clear();
                Console.WriteLine("Please Input a Code to be validated");
                string Input_ISBN = Console.ReadLine();
                if (HandlingError(Input_ISBN))          //Calls a function with the parameters being the user input, this function returns true or false depending on wether the user inputs a valid format string.
                {
                    ISBN_Validator(Input_ISBN);         //If its valid, proceed and process the string using the function containing the formula.
                }
                else
                {
                    Console.WriteLine("Enter A Valid Format For An ISBN Code");     //If not valid, return custom message and pass on.
                }

                Console.WriteLine("Would you like to enter a new Code?");
                string Choice = Console.ReadLine();                         //Asks the user if they want to input another code, if not yes then the loop is broken as loop is no longer true.
                if (Choice.ToUpper() != "Y")
                {
                    loop = false;
                }
             Thread.Sleep(3000);
             Menu();                            //Waits 3 seconds and then calls back to the function so they have enough time to read the message.
            }


        }
        static bool HandlingError(string InputString)           //Checks wether the user input is a valid format. Returns true or false as is static bool
        {
            char[] Digits = InputString.ToCharArray();          //Stores every character in the string in a character array.
            if (Digits.Length != 12)                            //If the string is longer than 12 characters,its invalid and returns false.
            {

                return false;
            }
            else
            {
                return true;                                    //If the string is the correct size, then its valid and returns true.
            }
        }

        static void ISBN_Validator(string InputString)          //Function that processes the input and checks wether it is a valid ISBN Code.
        {
            char[] Digits = InputString.ToCharArray();          //Stores every character in the string in a character array.
            int Verify_Return;                                  //Defines empty int variable

            if (Digits[12] == 'X')                       //If the last digit is X, modify the formula to change the last digit to 10
            {                                            
                Verify_Return = (Digits[0] * 10 + Digits[2] * 9 + Digits[3] * 8 + Digits[4] * 7 + Digits[6] * 6 + Digits[7] * 5 + Digits[8] * 4 + Digits[9] * 3 + Digits[10] * 2 + 3) % 11; //Since characters are stored in ascii, the formula is slightly different then expected.
                        
            }
            else
            {
                Verify_Return = (Digits[0] * 10 + Digits[2] * 9 + Digits[3] * 8 + Digits[4] * 7 + Digits[6] * 6 + Digits[7] * 5 + Digits[8] * 4 + Digits[9] * 3 + Digits[10] * 2 + Digits[12] * 1) % 11; //Original formula for the ISBN validator.
            }




            if (Verify_Return == 0)     //If the ISBN Formula returns 0, it is a valid code and returns corresponding message.
            {
                Console.WriteLine("Valid");
            }
            else                      //If it is not 0, then it is not valid and returns a different message.
            {
                Console.WriteLine("Invalid");

            }
            
        }
    }
}


/*

TEST DATA FOR INPUTS AND OUTPUTS:


MENU)
Input,Expected Output, Actual Output:

a,sends you to trinary function, program correctly directs user to trinary function.
b, sends you to school roster function, program correctly directs user to School roster function.
c, sends you to ISBN function, program halts,no such function exists in current context. Mistyped Function name, now corrected and correctly directs to function.
q, Exiting menu, Exiting menu


TRINARYTODECIMAL)
Input,Expected Output, Actual Output:

101,Decimal Equivalent:10,Decimal Equivalent:10
12,Decimal Equivalent:5,Decimal Equivalent:5
15,invalid format,Please enter a valid format for the trinay number Output:0
0000000,Decimal Equivalent:0,Decimal Equivalent:0
1a0,invalid format,Please enter a valid format for the trinay number Output:0


SCHOOLROSTER)
Input,Expected Output, Actual Output:

a,Enter the name and form,Enter the name of the student followed by the form, Using the format Student,Form:
b,Enter a name to check form number,Enter the name of a student to see which form they are in: Student Name:
c,Enter a form number,Enter the number of the form you wish to view:
d,Enter a valid input,Please Enter a valid input format Would you like to check anything else:

a->billy,3 , Billy has been added to form 3, billy has been added to form 3 Would you like to check anything else:
a->billy,3 -> y, *Goes back to school menu*, *Went back to school menu*
a->billy,3 -> n, *Goes back to main menu*, *Went back to main menu*

billy,3,4  , Enter only two inputs, Include only two inputs
3,billy    , Enter valid format, Please Enter valid format

b->billy, billy is in form 3,billy is in form 3
jack, jack is not found, Student not found in any form.

c->3, Students in form: billy, The list of students in form 3 are: billy
c->a, incorrect format, Please type in a correct number for a form
c->10, incorrect format, Please type in a correct number for a form

ISBN VERIFIER)
Input,Expected Output, Actual Output:

3-598-21508-8, Valid, Valid
3-598-21507-X, Valid, Valid
3-598-21508-9, Invalid, Invalid
1213, Please use correct format, Enter A Valid Format For An ISBN Code





*/


