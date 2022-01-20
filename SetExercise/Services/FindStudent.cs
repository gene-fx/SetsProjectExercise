using System;
using System.IO;

namespace SetExercise.Services
{
    class FindStudent
    {
        public string StudentInfo;

        public string FindStudentByName(String name)
        {
            string path = Path.GetTempPath();

            if (File.Exists(path + @"setExercise\Students.txt"))
            {
                string[] lines = File.ReadAllLines(path + @"setExercise\Students.txt");

                int firstIndex = 0;
                int lastIndex = 0;
                int nameLenght = 0;
                foreach (string line in lines)
                {
                    firstIndex = line.LastIndexOf('-');
                    lastIndex = line.IndexOf(',');
                    nameLenght = lastIndex - firstIndex - 1;
                    string registryName = line.Substring(firstIndex + 1, nameLenght);

                    if (string.Equals(registryName, name))
                    {
                        StudentInfo = line.ToString();
                    }
                }
            }
            else
                return "File is empty";

            if (StudentInfo != null)
                return "\nTeacher Info: " + StudentInfo;
            else
                return "Teacher not found";
        }

        public string FindStudentById(int id)
        {
            string path = Path.GetTempPath();

            if (File.Exists(path + @"setExercise\Students.txt"))
            {
                string[] lines = File.ReadAllLines(path + @"setExercise\Students.txt");

                int firstIndex = 0;

                foreach (string line in lines)
                {
                    firstIndex = line.LastIndexOf('-');
                    Console.WriteLine(line.Substring(0, firstIndex));
                    Console.ReadLine();
                    if (string.Equals(line.Substring(0, firstIndex), id.ToString()))
                    {
                        StudentInfo = line;
                    }
                    else
                        Console.WriteLine("No studant found!");
                }
            }
            else
                return "File is empty";

            if (StudentInfo != null)
                return "\nTeacher Info: " + StudentInfo;
            else
                return "Teacher not found";
        }
    }
}