using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryApp
{
    class Program
    {
        //Product
        public abstract class ISavingsAccount
        {
            public decimal Balance { get; set; }
        }
        public class CitySavingsAccount : ISavingsAccount
        {
            public CitySavingsAccount()
            {
                Balance = 5000;
            }
        }
        public class NationalSavingsAccount : ISavingsAccount
        {
            public NationalSavingsAccount()
            {
                Balance = 2000;
            }
        }
        //Creator
        interface ICreditUnionFactory
        {
            ISavingsAccount GetSavingsAccount(string accNo);
        }
        //Concrete Creators
        public class SavingsAccountFactory : ICreditUnionFactory
        {
            ISavingsAccount ICreditUnionFactory.GetSavingsAccount(string accNo)
            {
                if (accNo.Contains("CITY")) { return new CitySavingsAccount(); }
                else if (accNo.Contains("NAT")) { return new NationalSavingsAccount(); }
                else
                {
                    throw new ArgumentException("Invalid Account Number");
                }
            }
        }
        static void Main(string[] args)
        {
            //This pattern is simply about requesting objects that are created behind
            //the scenes and having the correct type of the object returned to you. 

            /*Story
             * Suppose two Credit Union merge and they share an API to pull account information 
             * from each company that merged, one called CityCreditUnion and other National Credit
             * Union. The api returns an Savings account object depending on the a/c passed in to it
            */
            var factory = new SavingsAccountFactory() as ICreditUnionFactory;
            var cityAccount = factory.GetSavingsAccount("CITY-01245");
            var nationalAccount = factory.GetSavingsAccount("NAT-12345");

            Console.WriteLine($"My city balance is {cityAccount.Balance}");
            Console.WriteLine($"My National account balance is {nationalAccount.Balance}");
            Console.ReadLine();
        }
    }
}
