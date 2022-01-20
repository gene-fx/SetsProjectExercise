using System.IO;
using System.Text;
using System.Collections.Generic;

namespace SetExercise.Entities
{
    class Course
    {
        public string Name { get; set; }
        public int Id { get; private set; }
        public Teacher Teacher { get; set; }

        public HashSet<Student> EnrolledStudendts { get; set; }


        public Course(string name)
        {
            Name = name;
        }

        public void AddTeacher(Teacher teacher)
        {
            Teacher = teacher;
        }

        public void AddId()
        {
            Id = Name.GetHashCode() + Teacher.GetHashCode();
        }

        public void SetEnrolledStudents(Student student)
        {
            EnrolledStudendts = new HashSet<Student> { student };   
        }
        
        public HashSet<Student> GetEnrolledStudents()
        {
            return EnrolledStudendts;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Course))
                return false;

            Course other = obj as Course;
            return Id.Equals(obj);
        }
    }
}
