namespace GradedExercise6
{
    /// <summary>
    /// Graded Exercise 6 solution
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Demonstrates polymorphism
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // create a list for all of our investment accounts
            List<InvestmentAccount> accounts = new List<InvestmentAccount>();

            // add a savings account with a 3% interest rate
            SavingsAccount savings = new SavingsAccount(100, 0.03f);
            accounts.Add(savings);

            // add a mutual fund
            MutualFund mutual = new MutualFund(100);
            accounts.Add(mutual);

            // add an employer sponsered account
            EmployerSponsoredAccount sponsered = new EmployerSponsoredAccount(100);
            accounts.Add(sponsered);

            // print all account balances
            foreach (InvestmentAccount account in accounts)
            {
                Console.WriteLine(account.ToString());
            }

            // print a blank line
            Console.WriteLine();

            // update all balances in the accounts
            foreach (var account in accounts)
            {
                account.UpdateBalance();
            }

			// print out account balances again 
			foreach (InvestmentAccount account in accounts)
			{
				Console.WriteLine(account.ToString());
			}

            // pirnt a blank line
            Console.WriteLine();

            // add $100 to each account
            foreach (InvestmentAccount account in accounts)
            {
                account.AddMoney(100);
            }

			// print out account balances a final time 
			foreach (InvestmentAccount account in accounts)
			{
				Console.WriteLine(account.ToString());
			}
		}
    }
}
