using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTodo.Api.Models
{
    public class TestStudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>()
        {
            new Student() { 
                StudentId = 1,
                Name = "Kevin Leon",
                Gender = Gender.Male,
                Title = "Kevin's title",
                Description = "Kevin's Description"
            },
            new Student() { 
                StudentId = 2,
                Name = "Jason Tyson",
                Gender = Gender.Male,
                Title = "Jason's title",
                Description = "Jason's Description"
            },
            new Student() { 
                StudentId = 3,
                Name = "Daniel Sales",
                Gender = Gender.Male,
                Title = "Daniel's title",
                Description = "Daniel's Description"
            },
            new Student() { 
                StudentId = 4,
                Name = "Thomas Corriea",
                Gender = Gender.Male,
                Title = "Thomas's title",
                Description = "Thomas's Description"
            },
            new Student() { 
                StudentId = 5,
                Name = "Anna Linda",
                Gender = Gender.Female,
                Title = "Anna's title",
                Description = "Anna's Description"
            }
        };

        public List<Student> DataSource()
        {
            return students;
        }

        public Student GetStudentById(int StudentId)
        {
            return students.FirstOrDefault(e => e.StudentId == StudentId);
        }

        public void AddStudent(Student student)
        {
            if(students.Count() == 0) student.StudentId = 0;
            else student.StudentId = students[students.Count() - 1].StudentId + 1;

            // Console.WriteLine(student.Title);
            // Console.WriteLine(student.Name);
            // Console.WriteLine(student.Gender);
            // Console.WriteLine(student.Description);
            // Console.WriteLine(student.StudentId);
            students.Add(student);
            
            // foreach (var studentitem in students) {
            //     Console.WriteLine(string.Join(" ",studentitem.GetType().GetProperties().Select(prop => prop.GetValue(studentitem))));
            // }
        }

        public List<Student> GetStudentsByTitle(string Title)
        {
            return DataSource().FindAll((e) => {
                if (e.Title.Contains(Title) == true) return true;
                else return false;
            });
        }
    }
}