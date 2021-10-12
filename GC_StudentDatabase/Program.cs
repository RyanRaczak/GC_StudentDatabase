using System;
using System.Collections.Generic;

namespace GC_StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Construct a list of students
            //Prompt user to ask about a particular student
            //Allow students to be searched by name or number
            //Validate all inputted information - Indexes, menu options, continues, etc..
            //Display information based on user input - Allow for more then 2 pieces of info about the student
            //Loop if user chooses to continue

            //Printing Database for testing
            List<Student> students = CreateStudents();
            Console.WriteLine("For reference: Here is the database for testing.");
            for (int i = 0; i < students.Count; i++)
            {
                students[i].DisplayInfo();
            }

            //Welcome
            Console.WriteLine("\n\nWelcome to the Student Database\n");
            string input;
            int index;
            bool userContinue = true;
            //Main program loop
            while (userContinue)
            {
                //input and validation
                input = GetInput("\nWould you like to search?\n1) Name \n2) Number\n\n: ");
                if (ValidateNum(input))
                {
                    if (ValidateRange(1, 2, int.Parse(input)))
                    {
                        //searching list
                        index = SearchStudents(students, int.Parse(input));
                        if (index > 0)
                        {
                            //calling method to display desired info
                            DisplayInfo(students, index);
                            userContinue = UserContinue();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please enter 1 or 2...");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter the number 1 or 2...");
                }
            }
        }

        static List<Student> CreateStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student(1, "Rocky", "Balboa", "Detroit", "Eggs", "Boxing"));
            students.Add(new Student(2, "Jonny", "Smith", "Macomb", "Tacos", "Fishing"));
            students.Add(new Student(3, "Billy", "Jean", "Sterling Heights", "Cheese", "Singing"));
            students.Add(new Student(4, "Kelsey", "Jacobs", "San Francisco", "Beans", "Walking"));
            students.Add(new Student(5, "Justin", "Doe", "San Francisco", "Steak", "DJ"));
            students.Add(new Student(6, "Matt", "Declercq", "Sterling Heights", "Burritos", "Gaming"));
            students.Add(new Student(7, "Ryan", "Raczak", "Macomb", "Chicken", "Gaming"));
            students.Add(new Student(8, "Paul", "Weber", "Dandridge", "Ribs", "D&D"));
            students.Add(new Student(9, "Ray", "Batonia", "Utica", "Cigs", "Reading"));
            students.Add(new Student(10, "Michael", "Jackson", "Detroit", "Chicken", "Dancing"));
            return students;
        }
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().ToLower();
        }
        public static bool ValidateNum(string input)
        {
            double num;
            if (double.TryParse(input, out num))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nPlease enter an actual number...");
                return false;
            }
        }
        public static bool ValidateRange(double min, double max, double num)
        {
            if (min < max)
            {
                if (num >= min && num <= max)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"\n{num} is out of range...");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"\n{min} as min was set larger than {max} as max. Can't check range...");
                return false;
            }
        }
        public static bool UserContinue()
        {
            string input = GetInput("\n\nWould you like to run the program again? (y/n)");
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("\nEnding program...");
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid input...please enter y or n...");
                return UserContinue();
            }
        }
        public static int SearchStudents(List<Student> students, int selection)
        {
            //Searches a list and returns the index
            string input;
            if (selection == 1)
            {
                input = GetInput($"\nPlease enter the student's last name: ");
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].LastName.Equals(input))
                    {
                        Console.WriteLine("\nStudent had been found.");
                        return i;
                    }
                }

            }
            //Number
            else if (selection == 2)
            {
                //Won't end until a valid number is inputted.
                // while (true) //<-uncomment to require valid range. 
                //{

                input = GetInput($"\nThere are currently {students.Count} students.\nPlease enter the student number: ");
                if (ValidateNum(input))
                {
                    if (ValidateRange(1, 10, int.Parse(input)))
                    {
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].StudentNum.Equals(int.Parse(input)))
                            {
                                Console.WriteLine("\nStudent had been found.");
                                return i;
                            }
                        }
                    }
                }
                //}
            }
            Console.WriteLine("\nStudent was not found...");
            return 0;
        }
        public static void DisplayInfo(List<Student> students, int index)
        {
            //Takes a list and index and displays desired information
            bool userContinue = true;
            while (userContinue)
            {
                Console.WriteLine("\nWhat would you like to learn about the student?" +
                    "\n1) Full Name" +
                    "\n2) Hometown" +
                    "\n3) Fav Food" +
                    "\n4) Fav Hobby" +
                    "\n5) Exit");

                string input = GetInput("\n\nPlease enter a number from the menu: ");
                if (ValidateNum(input))
                {
                    if (ValidateRange(1, 5, int.Parse(input)))
                    {
                        int selection = int.Parse(input);
                        switch (selection)
                        {
                            case 1:
                                Console.WriteLine($"\nThe student's full name is " +
                                    $"{char.ToUpper(students[index].FirstName[0]) + students[index].FirstName.Substring(1)} " +
                                    $"{char.ToUpper(students[index].LastName[0]) + students[index].LastName.Substring(1)}");
                                break;
                            case 2:
                                Console.WriteLine($"\nThe student's Hometown is {students[index].HomeTown}");
                                break;
                            case 3:
                                Console.WriteLine($"\nThe student's favorite food is {students[index].FavFood}");
                                break;
                            case 4:
                                Console.WriteLine($"\nThe student's favorite hobby is {students[index].FavHobby}");
                                break;
                            case 5:
                                userContinue = false;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please enter a number 1-5...");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a number...");
                }
            }
        }

    }
}
