using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class MyBankAccount
    {
        public int AccountNumber { get; }
        public string Owner { get; }

        private readonly List<Transaction> allTransactions = new List<Transaction>();

        public MyBankAccount(int accountNumber, string name, decimal initialBalance)
        {
            Owner = name;
            AccountNumber = accountNumber;

            InitializeBalance(initialBalance);
        }
        private void InitializeBalance(decimal initialBalance)
        {
            allTransactions.Add(new Transaction(initialBalance, DateTime.UtcNow, "INITAL AMOUNT"));
        }
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            //var withdrawal = new Transactions(-amount, date, note);
            //allTransactions.Add(withdrawal);

            if (GetCurrentBalance() - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);

        }

        public string GetAccountHistory()

        {
            var report = new StringBuilder();

            //HEADER
            report.AppendLine("Date\t\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Date}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }

        public decimal GetCurrentBalance()
        {
            decimal balance = 0;

            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }
}


