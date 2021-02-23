using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Student()
        {
            this.FirstName = "";
            this.LastName = "";
            this.Subject = "";
        }

        public Student(string _firstName, string _lastName, string _subject)
        {
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.Subject = _subject;
        }


        public override string ToString()
        {
            return $"Student: First Name = {this.FirstName}, " +
                $"Last Name = {this.LastName}, " +
                $"Subject = {this.Subject}";
        }



    }
}
