using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grade_sheets
{
    class Program
    {
        private static List<Student> students = new List<Student>(); // List of students

        static void Main(string[] args)
        {
            string uQuit = ""; // string used to determine whether the user wants to quit the program

            while (uQuit != "x") // While loop where condition is that the uQuit isn't 'x'
            {
                //  TEST
                students.Add(new Student("TEST", null, "TEST"));
                Console.Clear(); // Clear console
                Console.WriteLine("-----Welcome to Grade Sheets-----\n" +
                                  "   Enter the name of a student to see their grades\n" +
                                  "a. Press 'a' to add a student\n" +
                                  "d. Press 'd' to delete a student\n" +
                                  "x. Press 'x' if you want to exit the program"); // Main menu
                string userInput = Console.ReadLine(); // User input from readline

                if (userInput == "a") // if user's input is 'a'
                {
                    string uQuitAdd = ""; // string to determine whether user wants to quit this add menu

                    while (uQuitAdd != "d") // while loop condition is that uQuitAdd isn't 'd'
                    {
                        List<Grade> grades = new List<Grade>(); // List of grades
                        string uInputQuitGrading = ""; // string to determine whether user wants to quit grading menu

                        Console.WriteLine("Enter the name of the student you wish to add\n"); // cw
                        string uInputName = Console.ReadLine(); // user input name of student

                        Console.WriteLine($"Enter the class of {uInputName}\n"); // cw
                        string uInputClass = Console.ReadLine(); // user input school class

                        while (uInputQuitGrading != "d") // while loop condition uInputQuitGrading isn't 'd'
                        {
                            float uInputGrade = 0; // float for the user input grade
                            Console.WriteLine($"Enter {uInputName}'s subject to be graded\n"); // cw
                            string uInputSubject = Console.ReadLine(); // readline user input subject

                            Console.WriteLine($"Enter {uInputName}'s grade in {uInputSubject}\n"); // cw
                            bool succeeded = float.TryParse(Console.ReadLine(), out uInputGrade); // boolean to determine whether float.TryParse on the user input grade failed or not
                            if (!succeeded) // if the try parse failed
                            {
                                Console.WriteLine("Failed to add grade"); // cw
                            }
                            else if (succeeded && uInputGrade <= 0 && uInputGrade >= 12) // the try parse succeeded and user input grade is between 0 and 12
                            {
                                grades.Add(new Grade(uInputSubject, uInputGrade)); // Adds the grade to the grades list with user inputs as properties
                            }

                            Console.WriteLine($"d. Press 'd' if you don't want to add more grades to {uInputName}\n" +
                                              $"Any. Press any key if you want to continue adding grades to {uInputName}\n"); // cw
                            
                            uInputQuitGrading = Console.ReadLine(); // user input quit grading menu as readline
                        }

                        students.Add(new Student(uInputName, grades, uInputClass)); // adds student to the students list with user inputs as properties
                         
                        Console.WriteLine("d. Press 'd' to go back to the main menu\n"); // cw
                        uQuitAdd = Console.ReadLine(); // user quit add menu as readline
                    }
                }
                else if (userInput == "d") // if user input is 'd'
                {
                    string uInputStudentName = ""; // string to store the user input student name
                    string uQuitDelete = ""; // string to store user quit delete menu

                    while (uQuitDelete != "d") // while the user hasn't quit the menu
                    {
                        Console.WriteLine("Enter the name of the student you wish to delete\n" +
                                          "d. Press 'd' to go back to the main menu\n"); // cw
                        uInputStudentName = Console.ReadLine(); // user input student name as readline

                        if (students.Any(s => s.nme == uInputStudentName)) // Checks if the students list contains any elements where the students name is equal to the user's input
                        {
                            students.RemoveAll(s => s.nme == uInputStudentName); // Removes all the students where their name equals the user's input
                            Console.WriteLine($"{uInputStudentName} successfully deleted\n"); // cw
                        }
                        else if (uInputStudentName == "d") // if user input student name is 'd'
                        {
                            uQuitDelete = uInputStudentName; // sets user quit delete menu to 'd' i.e. quit the delete menu
                        }
                        else // Any other case
                        {
                            Console.WriteLine($"Something went wrong. Maybe {uInputStudentName} doesn't exist\n"); // cw
                        }
                    }
                }
                else if (students.Any(s => s.nme == userInput)) // if students list contains any elements where the name property is equal to the user input
                {
                    string uQuitGrades = ""; // user quit grade menu
                    string uInputGradeChoice = ""; // user input grade choice
                    Student student = students.Find(s => s.nme == userInput); // Finds a student where the user input is equal to the name property
                    List<Grade> grades = student.grds; // makes a list of grades equal to the grades list of the student object

                    if (grades.Count != 0)
                    {
                        while (uQuitGrades != "d") // while loop condition quser quit grades menu isn't 'd'
                        {
                            Console.WriteLine($"{student.nme} {student.schlCls}\n"); // cw

                            foreach (Grade grade in grades) // foreach loops through the grades list
                            {
                                Console.WriteLine($"{grade.sbjct} {grade.grd}"); // cw
                            }

                            Console.WriteLine($"a. Press 'a' if you want to see the single highest grade {student.nme} has gotten\n" +
                                              $"b. Press 'b' if you want to see the single lowest grade {student.nme} has gotten\n" +
                                              $"c. Press 'c' if you want to see the average of {student.nme}'s grades\n" +
                                               "d. Press 'd' if you want to go back to the main menu\n"); // cw menu
                            uInputGradeChoice = Console.ReadLine(); // user input grade choice as readline

                            switch (uInputGradeChoice) // switch on the user input grade choice
                            {
                                case "a": // in case the user input grade choice is 'a'
                                    float maxGrade = grades.Max(g => g.grd); // Find the highest grade of all the student's grades
                                    List<Grade> maxGradeObjects = grades.FindAll(g => g.grd == maxGrade); // List of all the student's Grade objects where the grade is the highest 

                                    foreach (Grade obj in maxGradeObjects) // Loop through the maxGradeObjects
                                    {
                                        Console.WriteLine($"{student.nme}'s highest grade is {obj.grd} in {obj.sbjct}\n"); // Cw for every object where the grade is the highest
                                    }
                                    break;
                                case "b": // in case the user input grade choice is 'b'
                                    float minGrade = grades.Min(g => g.grd); // Find the lowest grade of all the student's grades
                                    List<Grade> minGradeObjects = grades.FindAll(g => g.grd == minGrade); // List of all the student's Grade objects where the grade is the lowest 

                                    foreach (Grade obj in minGradeObjects) // Loop through the minGradeObjects
                                    {
                                        Console.WriteLine($"{student.nme}'s lowest grade is {obj.grd} in {obj.sbjct}\n"); // Cw for every object where the grade is the lowest
                                    }
                                    break;
                                case "c": // in case the user input grade choice is c
                                    float avgGrade = grades.Average(g => g.grd); // Average grade across the student's grades

                                    Console.WriteLine($"{student.nme}'s average across all grades is {avgGrade}\n"); // cw 
                                    break;
                                case "d": // in case the user input grade choice is 'd'
                                    uQuitGrades = uInputGradeChoice; // In case user wants to go back to main menu
                                    break;
                                default: // default case
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong. Perhaps the student doesn't have any grades.");
                    }
                }
                else if (userInput == "x") // In case user wants to quit program entirely
                {
                    uQuit = userInput; // sets user quit to equal user input i.e. quit program entirely
                }
            }
        }
    }
}
