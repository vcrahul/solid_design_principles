using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class OpenClose
    {
        public void OpenClosePrincipleMethod()
        {
            //lets use normal class which voilates open close principle
            Account_2 Rahul = new Account_2("Rahul","BLR",1500);
            Account_2 Ramesh = new Account_2("Ramesh", "BLR", 1500);
            Rahul.calculateInterest("Savings");
            Ramesh.calculateInterest("FixedDeposit"); // for this type of account we dont have condition in code so we need to modify;
            Console.WriteLine("As fixed deposit is not there in code we need to modify it so instead lets see how we can handle this by following open close principle");
            
            //Lets follow open close principle from now on
            Account Anand = new Account("Anand", "BLR", 1500);
            Account Suresh = new Account("Suresh", "BLR", 1500);
            Savings savingAcc = new Savings();
            savingAcc.CalculateInterest(Anand);
            //For fixed deposit account type we will create a new class which inherit interest interface and impelemnt new logic so that old class is modified.
            FixedDeposit fixedDeposit = new FixedDeposit();
            fixedDeposit.CalculateInterest(Suresh);
        }
    }

    //It voilates open close principles as if we need to add different types of account for calculation
    //then we need to modify this class to add new requirements which is not a good way
    public class Account_2
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int  Balance { get; set; }
        public Account_2(string name, string address, int balance)
        {
            Name = name;
            Address = address;
            Balance = balance;
        }
        public int calculateInterest(string accountType)
        {
            switch (accountType)
            {
                case "Savings":
                    return Balance * 12 / 100;
                case "Current":
                    return Balance * 5 / 100;
                default:
                    return 0;
            }
        }

    }

    // instead we can create abstract classes or interfaces to implement open close principle and avoid making modifications to existing classes
    // implement the method which tend to change in a interface or make it abstract
    public class Account
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Balance { get; set; }

        public Account(string name, string address, int balance)
        {
            Name = name;
            Address = address;
            Balance = balance;
        }
    }
    public interface Interest
    {
        int CalculateInterest(Account account);
    }

    public class Savings : Interest
    {
        public int CalculateInterest(Account account)
        {
            return account.Balance * 12 / 100;
        }
    }

    public class Current : Interest
    {
        public int CalculateInterest(Account account)
        {
            return account.Balance * 5 / 100;
        }
    }

    //creating new class for fixed deposit
    public class FixedDeposit : Interest
    {
        public int CalculateInterest(Account account)
        {
            return account.Balance * 8 / 100;
        }
    }

}
