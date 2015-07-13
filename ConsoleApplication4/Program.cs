using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerifyExpense
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string description = "";
            double expense = 0.0;
            string expenseInput = "";
            String hardwareItem = "";
            Console.WriteLine("Enter the item description, and expense: ");
            description = Console.ReadLine();
            expenseInput = Console.ReadLine();
            expense = double.Parse(expenseInput);
            FirstLvlMgr mgr = new FirstLvlMgr(description, expense);
            Console.WriteLine("Is the request for a hardware item? y/n");
            while (true) { 
                hardwareItem = Console.ReadLine();
            
                if (hardwareItem.Equals("y") || hardwareItem.Equals("Y"))
                {
                    mgr.IsHardwareItem = true;
                    break;
                }
                else if (hardwareItem.Equals("n") || hardwareItem.Equals("N"))
                {
                    mgr.IsHardwareItem = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Y/N");
                }
            }
            //string type = Console.ReadLine();
            //string description = Console.ReadLine();
            //double expense = double.Parse(Console.ReadLine());
            
            mgr.getDecision(mgr.IsHardwareItem);
            //decision(type, description, expense);
            
        }
        /*
        public static void decision(string type, string description, double expense)
        {
            bool accepted = false;
            if ((type == "hardware" && expense > 5000) || description == "town car" || description == "entertainment")
            {
                //return accepted;
                Console.WriteLine("Not approved");
                return;
            }
            else if (!description.Contains("entertainment") && expense <= 250)
            {
                accepted = true;
                Console.WriteLine("1st level manager approved");
                return;
            }
            if (!accepted && !description.Contains("town car") && expense <= 500)
            {
                accepted = true;
                Console.WriteLine("2nd level manager approved");
                return;
            }
            if (!accepted && expense > 1000)
            {
                accepted = true;
                Console.WriteLine("director approved");
                return;
            }
            else
            {
                Console.WriteLine("Not approved");
                return;
            }
           
        }
         */
    }
}

abstract class Manager
{
    public String description;
    public double expense;
    public bool IsHardwareItem { get; set; }
    //public abstract void getDecision();
    public abstract void getDecision(bool isHardware);
}

class FirstLvlMgr : Manager
{
    
    public FirstLvlMgr(string description, double expense){
        this.description = description;
        this.expense = expense;
    }
    public override void getDecision(bool isHardware)
    {
        
        
        SecondLvlMgr secondMgr = new SecondLvlMgr(description, expense);
        if(description.Contains("entertainment"))
        {
            Console.WriteLine("Request rejected by first level manager");
        }
        else if(expense <= 250)
        {
            Console.WriteLine("Request accepted by first level manager");
        }
        else
        {
            secondMgr.getDecision(isHardware);
        }
        
    }
}

class SecondLvlMgr : Manager
{
    public SecondLvlMgr(string description, double expense)
    {
        // TODO: Complete member initialization
        this.description = description;
        this.expense = expense;
    }

    public override void getDecision(bool isHardware)
    {
        Director director = new Director(expense);
        if(description.Contains("towncar"))
        {
            Console.WriteLine("Request rejected by second level manager");
        }
        else if (expense <= 500)
        {
            Console.WriteLine("Request accepted by second level manager");
        }
        else
        {
            director.getDecision(isHardware);
        }
    }
}

class Director : Manager
{
    public Director(double expense)
    {
        this.description = description;
        this.expense = expense;
    }

    public override void getDecision(bool isHardware)
    {
        if(isHardware && expense > 5000)
        {
            Console.WriteLine("Request rejected by director");
        }
        else if (expense <= 1000)
        {
            Console.WriteLine("Request accepted by director");
        }
        else
        {
            Console.WriteLine("Consult the CEO");
        }
    }
}
