using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrankBank.Controllers
{
    [Route("api/[controller]")] // api/bank
    public class BankController : Controller
    {
        private static AccountSummary[] _acctSummaries = new AccountSummary[]
        {
            new AccountSummary() { AccountNumber = "123-234-4567", Balance = 1234.56, Name = "Checking-S", Type = AccountType.Checking },
            new AccountSummary() { AccountNumber = "234-456-3224", Balance = 4562.14, Name = "Savings-S", Type = AccountType.Savings },
            new AccountSummary() { AccountNumber = "1113-2222-4444", Balance = 652.02, Name = "CreditCard-S", Type = AccountType.Credit }
        };


        [HttpGet("[action]")]
        public IActionResult GetAccountSummaries()
        {
            return new ObjectResult(_acctSummaries);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetAccountDetail(string id)
        {
            var summary = _acctSummaries.FirstOrDefault(a => a.AccountNumber == id);
            if (summary == null)
                return NotFound();

            var random = new Random();
            var transactions = new List<AccountTransaction>();

            for (int i=0; i < 15; i++)
            {
                transactions.Add(new AccountTransaction
                {
                    TransactionDate = DateTimeOffset.Now - TimeSpan.FromDays(i),
                    Description = $"Server transaction #{i}",
                    Amount = random.NextDouble() * 500 - 250
                });
            }

            return new ObjectResult(new AccountDetail() {
                AccountSummary = summary,
                AccountTransactions = transactions.ToArray()
            });
        }

    }

    public enum AccountType
    {
        Checking,
        Savings,
        Credit
    }

    public class AccountSummary
    {
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }

    public class AccountTransaction
    {
        public DateTimeOffset TransactionDate { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }

    public class AccountDetail
    {
        public AccountSummary AccountSummary { get; set; }
        public AccountTransaction[] AccountTransactions { get; set; }
    }
}
