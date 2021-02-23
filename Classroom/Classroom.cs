using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {

        private List<Student> students;

     
        public int Capacity { get; set; }

        public int Count { get; set; }

        public Classroom(int _capacity)
        {
            this.Capacity = _capacity;
            this.students = new List<Student>();
            this.Count = 0;
        }

        public string RegisterStudent(Student _student)
        {
            
            if(this.students.Where(s => s.FirstName == _student.FirstName && s.LastName == _student.LastName).FirstOrDefault() != null)
            {
                return "No seats in the classroom";
            }

            else if (this.Count >= this.Capacity)
            {
                return "No seats in the classroom";
            }

            else
            {
                this.students.Add(_student);
                this.Count++;
                return $"Added student {_student.FirstName} {_student.LastName}";
            }
        }


        public string DismissStudent(string _firstName, string _lastName)
        {
            Student student = this.students
                .Where(s => s.FirstName == _firstName && s.LastName == _lastName)
                .FirstOrDefault();

            if (student != null)
            {
                this.students.Remove(student);
                this.Count--;
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }


        public string GetSubjectInfo(string _subject)
        {
            List<Student> filteredStudents = new List<Student>();
            string allStudentsInfo = "";
            if (this.Count > 0)
            {
                foreach (var student in this.students.Where(s => s.Subject == _subject))
                {
                    filteredStudents.Add(student);
                }

                if (filteredStudents.Count == 0)
                {
                    Console.WriteLine("No students enrolled for the subject");
                }
                else
                {
                    allStudentsInfo += $" Subject: {_subject} \n";
                    allStudentsInfo += "Students: \n";
                    foreach (var student in filteredStudents)
                    {
                        allStudentsInfo += $"{student.FirstName} {student.LastName}\n";
                    }
                }
            }


            return allStudentsInfo;
        }


        public int GetStudentsCount()
        {
            return this.Count;
        }


        public Student GetStudent(string _firstName, string _lastName)
        {
            Student searchedStudent = new Student();
            if (this.Count > 0)
            {
                searchedStudent = this.students
               .Where(s => s.FirstName == _firstName && s.LastName == _lastName)
               .FirstOrDefault();
            }

            return searchedStudent;
        }





    }
}
