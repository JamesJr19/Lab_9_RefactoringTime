using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //string list with fellow students names
        List<string> names = new List<string> { "Sean", "Blake", "James" };

        //string list for hometown
        List<string> hometown = new List<string> { "Ann Arbor", "Madison Heights", "Lake orion" };

        //repeat above for the final arrays of information you want
        List<string> food = new List<string> { "chicken", "pizza", "tacos" };

        //create another list of favorite numbers
        List<string> favNumber = new List<string> { "73", "99", "19" };

        Console.WriteLine("Welcome to C# January 2020.");
        Console.WriteLine();

        //keyword HereWeGo to move about the code using goto
    HereWeGo:
        Console.WriteLine("Would you like to: \n1. Get to know your classmates or \n2. Add new classmate?\n");
        Console.WriteLine("Enter 1 or 2");
        Console.WriteLine();
        string wouldYou = Console.ReadLine();
        if (wouldYou == "1" || wouldYou == "2")
        {
            goto LetsContinue;
        }
        else
        {
            goto HereWeGo;
        }

    LetsContinue:
        //declare variables before while loop
        bool userChoice = true;
        bool repeat = true;
        int student = 1;

        //if loop to ask if user wants to add classmate
        if (wouldYou == "1")
        {
            //use while loop to see if user would like to repeat
            while (repeat)
            {
                Console.WriteLine("Class Directory:");
                //loop through
                for (int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {names[i]}");
                    //assuring that it's 1. person 2.person...not 0.person
                }

                Console.WriteLine();
                student = RangeCheck(int.Parse(GetUserInput("Pick a number to learn more about that student?")), 1, names.Count);
                Console.WriteLine($"Classmate {student} is {names[student - 1]}.");

                //use another while loop for choice validaiton
                while (userChoice)
                {
                MoreStudentInfo:

                    //ask user what to learn next
                    string topic = GetUserInput($"What would you like to know about {names[student - 1]}. (Hometown, Food, or Number?)").ToLower();
                    //switch cases to navigate and validate users inputs
                    switch (topic)
                    {
                        case "hometown":
                            Console.WriteLine($"{names[student - 1]} is from {hometown[student - 1]}.");
                            Console.WriteLine("Would you like to learn more about this student? y/n?");
                            string continue1 = Console.ReadLine();

                            //continue based on user input
                            if (continue1 == "n")
                            {
                                goto HereWeGo;
                            }
                            else if (continue1 == "y")
                            {
                                goto MoreStudentInfo;
                            }
                            break;

                        case "food":
                            Console.WriteLine($"{names[student - 1]}'s favorite food is {food[student - 1]}.");
                            Console.WriteLine("Would you like to learn more about this student? y/n?");
                            string continue2 = Console.ReadLine();

                            //continue based on user input
                            if (continue2 == "n")
                            {
                                goto HereWeGo;
                            }
                            else if (continue2 == "y")
                            {
                                goto MoreStudentInfo;
                            }
                            break;

                        case "number":
                            Console.WriteLine($"{names[student - 1]}'s favorite number is {favNumber[student - 1]}.");
                            Console.WriteLine("Would you like to learn more about this student? y/n?");
                            string continue3 = Console.ReadLine();

                            //continue based on user input
                            if (continue3 == "n")
                            {
                                goto HereWeGo;
                            }
                            else if (continue3 == "y")
                            {
                                goto MoreStudentInfo;
                            }
                            break;

                        //default statement so if anything else is besides  whats in the case is entered it prompts them again
                        default:
                            Console.WriteLine("This data doesnt exist for this person.");
                            break;
                    }
                    userChoice = true;
                    Console.WriteLine("Would you like to learn about another student, y/n?\n");
                    string learnMore = Console.ReadLine();

                    if (learnMore == "y")
                    {
                        goto HereWeGo;
                    }
                    else if (learnMore == "n")
                    {
                        goto ThisIsTheEnd;
                    }
                }
            }
        }

        else if (wouldYou == "2")
        {
            //add new user method here
            names.Add(GetUserInput("What is the name of the student you wish to add?\n"));
            hometown.Add(GetUserInput("Where are they from?\n"));
            food.Add(GetUserInput("What is their favorite food?\n"));
            favNumber.Add(GetUserInput("What is their favorite number?\n"));

            Console.WriteLine("Thanks. Let's start over\n");

            goto HereWeGo;

        }
        else
        {
            Console.WriteLine("invalid input");
        }

    ThisIsTheEnd:;
    }

    //user input method
    public static string GetUserInput(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    //number input validation
    public static int RangeCheck(int number, int lower, int upper)
    {
        if (number >= lower && number <= upper)
        {
            return number;
        }
        else
        {
            Console.WriteLine($"Invalid Input. Input should be between {lower}-{upper}");
            number = int.Parse(Console.ReadLine());
            return RangeCheck(number, lower, upper);
        }
    }
}