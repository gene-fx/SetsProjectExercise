using System;
using System.IO;
using System.Collections.Generic;
using SetExercise.Entities;

namespace SetExercise.Services
{
    class FindCourse
    {
        public FindCourse(Course course)
        {
            string path = Path.GetTempPath();

            if (File.Exists(path + @"setExercise\Courses\" + course.Name + ".txt"))
            {
                string courseTeacher;
                SortedSet<string> courseStudents = new SortedSet<string>();

                string[] lines = File.ReadAllLines(path + @"setExercise\Courses\" + course.Name + ".txt");
                int index = lines[0].IndexOf(':');
                int nameLength = lines[0].Length - index - 1;
                courseTeacher = lines[0].Substring(index + 1, nameLength);

                foreach (string line in lines)
                {
                    if (line.StartsWith(" "))
                    {
                        courseStudents.Add(line);
                    }
                }
                Console.WriteLine("Course ID:" + course.Id + "Teacher: " + courseTeacher);
                Console.WriteLine("\nEnrolled Students:");
                foreach(String student in courseStudents)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("Course not found");
            }
        }
    }
}
