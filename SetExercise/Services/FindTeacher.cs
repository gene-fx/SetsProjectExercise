using System;
using System.IO;
using SetExercise.Entities;

namespace SetExercise.Services
{
    class FindTeacher
    {
        public string TeacherInfo = null;

        public string FindTeacherByName(String name)
        {
            string path = Path.GetTempPath();

            if (!File.Exists(path + @"setExercise\Teachers.txt"))
            {
                Console.WriteLine("File is empty");
            }
            else
            {
                int firstIndex = 0;
                int lastIndex = 0;
                int nameLenght = 0;

                string[] lines = File.ReadAllLines(path + @"setExercise\Teachers.txt");
                //line.Substring(firstIndex + 1, nameLenght - 1).Equals(name)
                foreach (string line in lines)
                {
                    firstIndex = line.LastIndexOf('-');
                    lastIndex = line.IndexOf(',');
                    nameLenght = lastIndex - firstIndex - 1;
                    if (string.Equals(line.Substring(firstIndex + 1, nameLenght).ToUpper(), name.ToUpper()))
                    {
                        TeacherInfo = line.ToString();
                    }
                }
            }
            if (TeacherInfo != null)
                return TeacherInfo;
            else
                return "Teacher not found";

        }

        public string FindTeacherById(int id)
        {
            string path = Path.GetTempPath();

            if (File.Exists(path + @"setExercise\Teachers.txt"))
            {

                string[] lines = File.ReadAllLines(path + @"setExercise\Teachers.txt");

                int firstIndex = 0;

                foreach (string line in lines)
                {
                    firstIndex = line.LastIndexOf('-');
                    if (line.Substring(0, firstIndex) == id.ToString())
                    {
                        TeacherInfo = line.ToString();
                    }
                }
            }
            else
                return "File is empty";

            if (TeacherInfo != null)
                return TeacherInfo;
            else
                return "Teacher not found";
        }
    }
}
