using System;
using System.IO;
using System.Text;
using SetExercise.Entities;

namespace SetExercise.Services
{
    class Registration
    {
        public void CourseRegistration(Course course)
        {
            string path = Path.GetTempPath();
            try
            {
                using (FileStream fs = new FileStream(path + @"setExercise\Courses\" + course.Name + ".txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(course.Name + "," + course.Id + ":" + course.Teacher.Name);
                        sb.AppendLine("Enrolled Studants:");
                        foreach (Student studant in course.EnrolledStudendts)
                            sb.AppendLine(" " + studant.Cod + " - " + studant.Name);

                        long endPoint = fs.Length;
                        fs.Seek(endPoint, SeekOrigin.Begin);
                        sw.WriteLine(sb.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public void TeacherRegistration(Teacher teacher)
        {
            string path = Path.GetTempPath();

            using (FileStream fs = new FileStream(path + @"setExercise\Teachers.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    StringBuilder sb = new StringBuilder(teacher.Id + "-" + teacher.Name + "," + teacher.Email);

                    long endPoint = fs.Length;
                    fs.Seek(endPoint, SeekOrigin.Begin);
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        public void StudentRegistration(Student student)
        {
            string path = Path.GetTempPath();

            using (FileStream fs = new FileStream(path + @"setExercise\Studants.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    StringBuilder sb = new StringBuilder(student.Cod + "-" + student.Name + "," + student.Email);

                    long endPoint = fs.Length;
                    fs.Seek(endPoint, SeekOrigin.Begin);
                    sw.WriteLine(sb.ToString());
                }
            }
        }
    }
}
