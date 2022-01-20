using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SetExercise.Entities
{
    class Teacher
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; private set; }


        public Teacher(string name, string email)
        {
            Name = name;
            if (IsValidEmail(email))
                Email = email;
            Id = Email.GetHashCode();
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
            return Id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Teacher))
                return false;

            Teacher other = obj as Teacher;
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name + ", " + Email + ", " + Id);
            return sb.ToString();
        }
    }
}
