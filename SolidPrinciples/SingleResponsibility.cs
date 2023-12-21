using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class SingleResponsibility
    {   
        public void SingleResponsibilityMethod()
        {
            Console.WriteLine("Executing single responsibility Principle code");

            //using class that voilates single responsibility principle
            User_2 Anand = new User_2("Anand", "123", "test@email.com");
            Anand.DisplayName();
            Anand.AuthenticateUser();
            Anand.SendEmail();

            //using multiple classes to follow single responsibility principle
            User Rahul = new User("Rahul","123","test@email.com");
            Rahul.DisplayName();
            Auth auth = new Auth();
            auth.AuthenticateUser(Rahul);
            Email email = new Email();
            email.SendEmail(Rahul);
        }
    }

    //Class User_2 voilates SRP, it should ideally have only user related information or responsibility over only user related information
    //but this class has responsibility over authenticating user and also sending emails to him
    //because of this this class has too many unnecessery responsibilities

    class User_2
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public User_2(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void DisplayName()
        {
            Console.WriteLine($"The name of the user is {Name}");
        }

        public void AuthenticateUser()
        {
            Console.WriteLine($"Authenticating user = {Name}");
        }

        public void SendEmail()
        {
            Console.WriteLine($"Sending email to {Name} with address {Email}");
        }
    }

    //Class User follows Single responsibility principle

    class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void DisplayName()
        {
            Console.WriteLine($"The name of the user is {Name}");
        }
    }

    class Email
    {
        public bool SendEmail(User user)
        {
            Console.WriteLine($"Sending email to {user.Name} with address {user.Email}");
            return true;
        }
    }

    class Auth
    {
        public void AuthenticateUser(User user)
        {
            Console.WriteLine($"Authenticating user = {user.Name}");
        }
    }
}
