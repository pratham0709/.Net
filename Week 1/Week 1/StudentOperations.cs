using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentService
{
    private List<Student> students;
    private int currentUserId;

    public StudentService()
    {
        students = new List<Student>();
        currentUserId = 1;
    }

    public void AddStudent()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        if (!IsValidName(firstName))
        {
            Console.WriteLine("Invalid first name. Only letters and special characters are allowed.");
            return;
        }

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        if (!IsValidName(lastName))
        {
            Console.WriteLine("Invalid last name. Only letters and special characters are allowed.");
            return;
        }

        Console.Write("Enter age: ");
        if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
        {
            Console.WriteLine("Invalid age. Please enter a positive number.");
            return;
        }

        Student newStudent = new Student(firstName, lastName, age, currentUserId++);
        students.Add(newStudent);
        Console.WriteLine("Student added successfully!");
    }

    public void ShowAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("\nNo students to show.");
            return;
        }

        Console.WriteLine("\nAll Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.UserId}, Name: {student.FirstName} {student.LastName}, Age: {student.Age}");
        }
    }

    /* public void SearchStudent()
    {
        Console.WriteLine("\nSearch by: ");
        Console.WriteLine("1. First Name");
        Console.WriteLine("2. Last Name");
        Console.WriteLine("3. Age");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter first name: ");
                string firstName = Console.ReadLine();
                var studentsByFirstName = students.Where(s => s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)).ToList();
                DisplaySearchResults(studentsByFirstName);
                break;
            case "2":
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();
                var studentsByLastName = students.Where(s => s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
                DisplaySearchResults(studentsByLastName);
                break;
            case "3":
                Console.Write("Enter age: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Invalid age. Please enter a valid positive number.");
                    return;
                }
                var studentsByAge = students.Where(s => s.Age == age).ToList();
                DisplaySearchResults(studentsByAge);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    } */

    private void DisplaySearchResults(List<Student> searchResults)
    {
        if (searchResults.Count == 0)
        {
            Console.WriteLine("No matching students found.");
            return;
        }

        Console.WriteLine("\nSearch Results:");
        foreach (var student in searchResults)
        {
            Console.WriteLine($"ID: {student.UserId}, Name: {student.FirstName} {student.LastName}, Age: {student.Age}");
        }
    }

    public void DeleteStudent()
    {
        Console.Write("Enter the Student ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var studentToRemove = students.SingleOrDefault(s => s.UserId == userId);

        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine($"Student with ID {userId} has been deleted.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    private bool IsValidName(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && c != '-' && c != '_')
            {
                return false;
            }
        }
        return true;
    }
}
