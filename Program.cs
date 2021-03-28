using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
       static double monthly_housing , expensis, leftover, net, tax, gross;
       static int choice;
        static void Main(string[] args)
        {   Gross();
            Tax();
            expensis = Expense.Expenditures();
            System.Console.WriteLine("Please choose what you plan to do:\n1.Rent accomidation. \n2.Purchaseing a property.");
            choice = int.Parse(Console.ReadLine());
            monthly_housing = Expense.homeloan(choice);
            finalCalculations();
        }
        static void Gross(){
            System.Console.WriteLine("Please enter the monthly income before deductions");
            gross = int.Parse(Console.ReadLine());
        }
        static void Tax(){
            System.Console.WriteLine("Please enter the estimated monthly tax deductions");
            tax = int.Parse(Console.ReadLine());
            net = gross - tax;
        }

        static void finalCalculations(){
            double take = expensis+monthly_housing;
            if(choice == 2){
            if(gross/monthly_housing>=3){
                System.Console.Clear();
                Console.Beep();
                System.Console.WriteLine("home loan approval is unlikely");
                System.Console.WriteLine("Press anykey to continue...");
                System.Console.ReadKey();
            }}
            /** finish this part then it shall be complete**/
            leftover = net - take;
            System.Console.WriteLine("take:" + take);
            System.Console.WriteLine("net :" + net);
            System.Console.WriteLine("Money leftover after monthly deductions :");
			System.Console.WriteLine("R"+leftover);
            System.Console.ReadKey();
        }
    }

    abstract class Expense{

        static  double[] expenditure = new double[5] ;
        static  String[] questions = {"Please enter the monthly expenditure for Groceries","Please enter the monthly expenditure for Utillitis(Water and lights)","Please enter the monthly expenditure for travel(petrol included)","Please enter the monthly expenditure for cell phone and telephone","Please enter the combined monthly expenditure for other expenses"};
        static  double rent,ppp,deposit,repayMonths;
        static  String percentage = "0";

	//This method is used to obtain the total amout of expenditures per month
        public static double Expenditures(){
            //Array used to store expenditures
            double Total = 0;
             // loop used to obtain the amounts of the monthly expenditures
        for(int i=0; i<5;i++){
            System.Console.WriteLine(questions[i]);
            double holder = int.Parse(Console.ReadLine());
            expenditure[i]= holder;
            Total += holder;
            }
            return Total;
        }
		//This method is used to obtain the monthly accomidation amount
        public static double homeloan(int choice){
            double HomeTotal = 0;
            
            System.Console.Clear();
                if(choice == 1){
                    System.Console.WriteLine("Please enter the monthly rental amount");
                    rent = double.Parse(Console.ReadLine());
                    HomeTotal = rent;
                    System.Console.Clear();
                }else if(choice == 2){
                    System.Console.WriteLine("Please enter the purchase price of the property");
                // ppp = "Property Purchase Price"
                    ppp = double.Parse(Console.ReadLine());
                    System.Console.Clear();
                    System.Console.WriteLine("Please eneter the total deposit for the property");
                    deposit = double.Parse(Console.ReadLine());
                    System.Console.Clear();
                    System.Console.WriteLine("Please enter the intrest rate percentage");
                                                     percentage = Console.ReadLine();
/**This removes the '%' if the user inputs it**/    if(percentage.IndexOf('%') == 1){percentage = percentage.Remove(percentage.IndexOf('%'), 1);}
                                                     System.Console.Clear();
                    System.Console.WriteLine("Please enter the number of months to repay");
                    repayMonths = double.Parse(Console.ReadLine());
                    System.Console.Clear();
                    HomeTotal = calculatehomeloan();
                   


                }else{System.Console.WriteLine("You have made an invalid choice, please try again");homeloan(choice);}
            return HomeTotal;
        }
		
		
		
		// This method is used to calculate the Homeloan
		public static double calculatehomeloan(){
			
			double Deposit = deposit/100, intrest = double.Parse(percentage, System.Globalization.CultureInfo.InvariantCulture)/100, months = repayMonths,price = ppp;
				 double a = 0, b=0,c=0;
                 a = price-(price*Deposit);
                 b = 1+intrest*(months/12);
                 c = (a * b)/months;
                 return System.Math.Round(c, 2);		
		} 
    }
}
