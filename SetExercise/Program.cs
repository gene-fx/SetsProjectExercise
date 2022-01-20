using System;
using System.Collections.Generic;
using SetExercise.Entities;
using SetExercise.Services;

namespace SetExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt = 1000;

            try
            {
                while (opt != 0)
                {
                    Console.Clear();
                    Console.WriteLine("---------------Courses Management---------------");
                    Console.WriteLine("\n\n1. Courses options");
                    Console.WriteLine("\n2. Teachers options");
                    Console.WriteLine("\n3. Students options");
                    Console.WriteLine("\n0. Quit");
                    Console.Write("\nOption: ");
                    opt = int.Parse(Console.ReadLine());
                    while (opt < 0 || opt > 3)
                    {
                        Console.Write("Enter a valid option: ");
                        opt = int.Parse(Console.ReadLine());
                    }

                    switch (opt)
                    {
                        case 1:
                            int courseOpt = 1000;
                            Console.Clear();
                            Console.WriteLine("---------------Course Options---------------");
                            Console.WriteLine("\n\n1. Course registration");
                            Console.WriteLine("\n2. Couse Info");
                            Console.WriteLine("\n0. Return");
                            Console.Write("\nOption: ");
                            courseOpt = int.Parse(Console.ReadLine());
                            while (courseOpt < 0 || courseOpt > 2)
                            {
                                Console.Write("Enter a valid option: ");
                                courseOpt = int.Parse(Console.ReadLine());
                            }

                            switch (courseOpt)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("---------------Course Registration---------------");
                                    Console.Write("\nEnter the name of the course: ");
                                    string couseName = Console.ReadLine();
                                    Course course = new Course(couseName);

                                    Console.Write("\nEnter the name of the course's teacher: ");
                                    string teacherName = Console.ReadLine();
                                    FindTeacher findTeacher = new FindTeacher();
                                    string teacherInfo = findTeacher.FindTeacherByName(teacherName);
                                    if (teacherInfo == "Teacher not found" || teacherInfo == "File is empty")
                                    {
                                        Console.WriteLine("Teacher not registred!");
                                        Console.WriteLine("Please go back and registry the teacher first.");
                                        Console.WriteLine("------------------------------------------------");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(teacherInfo);
                                        teacherName = teacherInfo.Substring(teacherInfo.LastIndexOf('-') + 1, teacherInfo.IndexOf(',') - teacherInfo.LastIndexOf('-') - 1);
                                        int firstIndex = teacherInfo.IndexOf(',') + 1;
                                        string teacherEmail = teacherInfo.Substring(firstIndex, teacherInfo.Length - (teacherInfo.IndexOf(',') + 1));
                                        course.AddTeacher(new Teacher(teacherName, teacherEmail));
                                        course.AddId();
                                    }
                                    Console.Write("\nHow many students are enrolled in this course?: ");
                                    int studentsQtd = int.Parse(Console.ReadLine());
                                    for (int i = 0; i < studentsQtd; i++)
                                    {
                                        Console.WriteLine("\nName: ");
                                        string studentName = Console.ReadLine();
                                        FindStudent findStudent = new FindStudent();
                                        string studentInfo = findStudent.FindStudentByName(studentName);
                                        if (studentInfo == "Student not found" || studentInfo == "File is empty")
                                        {
                                            Console.WriteLine("Student not registred!");
                                            Console.WriteLine("Please go back and registry the student first.");
                                            Console.WriteLine("------------------------------------------------");
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadLine();
                                            break;
                                        }
                                        else
                                        {
                                            studentName = studentInfo.Substring(studentInfo.LastIndexOf('-') + 1, studentInfo.IndexOf(',') - studentInfo.LastIndexOf('-') - 1);
                                            int firstIndex = studentInfo.IndexOf(',') + 1;
                                            string studentEmail = studentInfo.Substring(firstIndex, studentInfo.Length - (studentInfo.IndexOf(',') + 1));
                                            Console.WriteLine(studentName + "  " + studentEmail);                                           
                                            course.SetEnrolledStudents(new Student(studentName, studentEmail));
                                        }
                                    }
                                    Registration reg = new Registration();
                                    reg.CourseRegistration(course);
                                    Console.WriteLine("\n\n\n----------------Course registred!");
                                    Console.WriteLine("\n\n");
                                    FindCourse findCourse = new FindCourse(course);
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("---------------Course Ifo---------------");
                                    Console.Write("\nEnter the name of the course: ");
                                    string couseInfoName = Console.ReadLine();
                                    Course courseInfoRequest = new Course(couseInfoName);
                                    findCourse = new FindCourse(courseInfoRequest);
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadLine();
                                    break;

                                case 0:
                                    break;
                            }
                            break;


                        case 2:
                            Console.Clear();
                            Console.WriteLine("---------------Teacher Options---------------");
                            Console.WriteLine("\n\n1. Teacher registration");
                            Console.WriteLine("\n2. Teacher Info");
                            Console.WriteLine("\n3. Students Count");
                            Console.WriteLine("\n0. Return");
                            Console.Write("\nOption: ");
                            int teacherOpt = int.Parse(Console.ReadLine());
                            while (teacherOpt < 0 || teacherOpt > 4)
                            {
                                Console.Write("Enter a valid option: ");
                                teacherOpt = int.Parse(Console.ReadLine());
                            }

                            switch (teacherOpt)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("---------------Teacher Registration---------------");
                                    Console.Write("\nEnter the teacher's name: ");
                                    string teacherRegName = Console.ReadLine();
                                    Console.Write("\nEnter the teacher's email: ");
                                    string teacherRegEmail = Console.ReadLine();
                                    Teacher teacher = new Teacher(teacherRegName, teacherRegEmail);
                                    Registration reg = new Registration();
                                    reg.TeacherRegistration(teacher);

                                    Console.WriteLine("\nTeacher registred");
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("---------------Teacher Info---------------");
                                    Console.Write("Name or id?: ");
                                    string nameOrId = Console.ReadLine();
                                    if (nameOrId.ToLower() == "id")
                                    {
                                        Console.Write("Enter the teacher's id: ");
                                        int findId = int.Parse(Console.ReadLine());
                                        FindTeacher findTeacherId = new FindTeacher();
                                        Console.WriteLine(findTeacherId.FindTeacherById(findId));
                                        Console.WriteLine("------------------------------------------------");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.Write("Enter the teacher's name: ");
                                        string findName = Console.ReadLine();
                                        FindTeacher findTeacherName = new FindTeacher();
                                        Console.WriteLine(findTeacherName.FindTeacherByName(findName));
                                        Console.WriteLine("------------------------------------------------");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadLine();
                                    }
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("---------------Student Count Per Teacher---------------");
                                    Console.Write("\nEnter the teacher's name: ");
                                    string teacherName = Console.ReadLine();
                                    StudentCount studentCount = new StudentCount();
                                    studentCount.PerTeacher(teacherName);
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadLine();
                                    break;

                                case 0:
                                    break;
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("---------------Student Options---------------");
                            Console.WriteLine("\n\n1. Student registration");
                            Console.WriteLine("\n2. Student Info");
                            Console.WriteLine("\n3. Students Count");
                            Console.WriteLine("\n0. Return");
                            Console.Write("\nOption: ");
                            int studentOpt = int.Parse(Console.ReadLine());
                            while (studentOpt < 0 || studentOpt > 4)
                            {
                                Console.Write("Enter a valid option: ");
                                studentOpt = int.Parse(Console.ReadLine());
                            }

                            switch (studentOpt)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("---------------Student Registration---------------");
                                    Console.Write("How many students do you wan'to registry: ");
                                    int Qtd = int.Parse(Console.ReadLine());
                                    for (int i = 0; i < Qtd; i++)
                                    {
                                        Console.Write("\nEnter the student's name: ");
                                        string studentRegName = Console.ReadLine();
                                        Console.Write("\nEnter the student's email: ");
                                        string studentRegEmail = Console.ReadLine();
                                        Student student = new Student(studentRegName, studentRegEmail);
                                        Registration reg = new Registration();
                                        reg.StudentRegistration(student);
                                    }
                                    Console.WriteLine("\nStudent registred");
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("---------------Student Info---------------");
                                    Console.Write("Name or id?: ");
                                    string nameOrId = Console.ReadLine();
                                    if (nameOrId.ToLower() == "id")
                                    {
                                        Console.Write("Enter the student's id: ");
                                        int findId = int.Parse(Console.ReadLine());
                                        FindStudent findStudentId = new FindStudent();
                                        Console.WriteLine(findStudentId.FindStudentById(findId)); 
                                        Console.WriteLine("------------------------------------------------");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.Write("Enter the student's name: ");
                                        string findName = Console.ReadLine();
                                        FindStudent findStudentName = new FindStudent();
                                        Console.WriteLine(findStudentName.FindStudentByName(findName));
                                        Console.WriteLine("------------------------------------------------");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadLine();
                                    }
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("---------------Student Count---------------");
                                    Console.WriteLine("\n\n1. Per teacher");
                                    Console.WriteLine("\n2. Per course");
                                    Console.WriteLine("\n0. Retutn");
                                    Console.Write("Option: ");
                                    int countOpt = int.Parse(Console.ReadLine());
                                    while(countOpt < 0 || countOpt > 2)
                                    {
                                        Console.Write("Enter a valid option: ");
                                        countOpt = int.Parse(Console.ReadLine());
                                    }

                                    switch (countOpt)
                                    {
                                        case 1:
                                            Console.WriteLine("---------------Student Count Per Teacher---------------");
                                            Console.Write("\nEnter the teacher's name: ");
                                            string teacherName = Console.ReadLine();
                                            StudentCount studentCount = new StudentCount();
                                            studentCount.PerTeacher(teacherName);
                                            Console.WriteLine("------------------------------------------------");
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadLine();
                                            break;

                                        case 2:
                                            Console.WriteLine("---------------Student Count Per Teacher---------------");
                                            Console.Write("\nEnter the teacher's name: ");
                                            string courseName = Console.ReadLine();
                                            StudentCount studentCountPerCourse = new StudentCount();
                                            studentCountPerCourse.PerCourse(courseName);
                                            Console.WriteLine("------------------------------------------------");
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadLine();
                                            break;

                                        case 0:
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
