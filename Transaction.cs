using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Transaction
    {
        public decimal Amount { get; init; }
        public DateTime Date { get; init; }
        public string Notes { get; init; }

        public Transaction(decimal amount, DateTime date, string notes)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = notes;
        }
    }
}
