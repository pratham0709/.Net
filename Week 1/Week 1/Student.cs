using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }

        public Student(string firstName, string lastName, int age, int userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserId = userId;
        }
    }
}
