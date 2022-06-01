namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new MyBankAccount(123456, "Lilitha", 1000);
            Console.WriteLine($"Account {account.AccountNumber} was created for {account.Owner} with {account.GetCurrentBalance()}.");

            account.MakeDeposit(500, DateTime.Now, "Headphones");
            Console.WriteLine(account.GetCurrentBalance());

        

            try
            {
                account.MakeWithdrawal(1000, DateTime.Now, "taxi fair");
                Console.WriteLine(account.GetCurrentBalance());

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
         
            }
            Console.WriteLine(account.GetAccountHistory());

            account.MakeDeposit(500, DateTime.Now, "Headphones");
            Console.WriteLine(account.GetCurrentBalance());


            /// account.MakeDeposit(-300, DateTime.Now, "Barbie dolls" )

            ////Test for negative balance
            //try
            //{
            //    account.MakeWithdrawal(75000, DateTime.Now, "attempt to over draw");
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance ");
            //    Console.WriteLine(e.ToString());
            //}


            // Test that initial balances must be positive.
            // try tests the code  
            //try
            //{
            //    var invalidAccount = new MyBankAccount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance ");
            //    Console.WriteLine(e.ToString());
            //}
        }
    }
}