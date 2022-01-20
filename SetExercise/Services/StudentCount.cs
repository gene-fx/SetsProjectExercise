using System;
using System.IO;
using System.Collections.Generic;

namespace SetExercise.Services
{
    class StudentCount
    {
        public StudentCount()
        {

        }

        public void PerTeacher(string name)
        {
            string path = Path.GetTempPath() + @"setExercise\Courses\";
            DirectoryInfo d = new DirectoryInfo(path);

            int studantCounter = 0;

            HashSet<string> Studants = new HashSet<string>();

            foreach (var file in d.GetFiles("*.txt"))
            {
                string[] lines = File.ReadAllLines(file.Name);

                int index = 0;

                if (lines[0].Substring(index + 1, lines[0].Length) == name)
                {
                    foreach (string line in lines)
                    {
                        if (line.StartsWith(" "))
                        {
                            Studants.Add(line);
                            studantCounter++;
                        }
                    }
                }

            }

            Console.WriteLine($"Nmber of studants for teacher {0}: {1}", name, studantCounter);
            Console.WriteLine("Studants list:");
            Console.WriteLine(Studants);
        }

        public void PerCourse(string course)
        {
            string path = Path.GetTempPath() + @"setExercise\Courses\";
            DirectoryInfo d = new DirectoryInfo(path);

            int studantCounter = 0;

            HashSet<string> Studants = new HashSet<string>();

            foreach (var file in d.GetFiles(course + ".txt"))
            {
                string[] lines = File.ReadAllLines(file.Name);

                foreach (string line in lines)
                {
                    if (line.StartsWith(" "))
                    {
                        Studants.Add(line);
                        studantCounter++;
                    }
                }
            }

            Console.WriteLine($"Nmber of studants for course {0}: {1}", course, studantCounter);
            Console.WriteLine("Studants list:");
            Console.WriteLine(Studants);
        }
    }
}
