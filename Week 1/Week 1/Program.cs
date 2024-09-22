using System;

class Program
{
    static void Main(string[] args)
    {
        StudentService studentService = new StudentService();

        while (true)
        {
            Console.WriteLine("\n1. Add Student");
            Console.WriteLine("2. Show All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    studentService.AddStudent();
                    break;
                case "2":
                    studentService.ShowAllStudents();
                    break;
                case "3":
                    studentService.SearchStudent();
                    break;
                case "4":
                    studentService.DeleteStudent();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
