using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        enum manager {level1, level2, director};
       

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the item type, description, and expense: ");
            string type = Console.ReadLine();
            string description = Console.ReadLine();
            double expense = double.Parse(Console.ReadLine());

            if (decision(type, description, expense))
            {
                Console.WriteLine("You got the OK");
            }
            else
            {
                Console.WriteLine("Not accepted");
            }
        }

        public static bool decision(string type, string description, double expense){
            bool accepted = true;
            if(type == "software"){
                if (!description.Contains("entertainment") && expense <= 250)
                {
                    return accepted;
                }
                else if (!description.Contains("town car") && expense <= 500)
                {
                    return accepted;
                }
                else if(expense <= 1000){
                     return accepted;
                }
                    
            }
            else if(type == "hardware" && expense > 5000){
                accepted = false;
            }
            return accepted;
        }
        
    }
}
