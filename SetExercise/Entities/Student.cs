using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;


namespace SetExercise.Entities
{
    class Student
    {
        public string Name { get; set; }
        public int Cod { get; private set; }
        public string Email { get; set; }

        public Student(string name, string email)
        {
            Name = name;
            Cod = email.GetHashCode();
            if (IsValidEmail(email))
                Email = email;
        }

        private bool IsValidEmail(string email)
        {
            string trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith('.'))
                return false;
            try
            {
                MailAddress addr = new MailAddress(trimmedEmail);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nError:");
                Console.WriteLine(e.Message);
                Console.WriteLine("------------------");
                Console.Write("\nEmail: ");
                email = Console.ReadLine();
                if (IsValidEmail(email))
                    return true;
                else
                    return IsValidEmail(email);
            }
        }
        

        public override int GetHashCode()
        {
            return Cod;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student))
                return false;

            Student other = obj as Student;
            return Cod.Equals(other.Cod);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name + ", " + Email + ", " + Cod);
            return sb.ToString();

        }
    }
}
