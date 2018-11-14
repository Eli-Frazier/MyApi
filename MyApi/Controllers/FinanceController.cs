using MyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApi.Controllers
{
    /// <summary>
    /// Finance
    /// </summary>
    [RoutePrefix("api/Finance")]
    public class FinanceController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Get A household from its Id
        /// </summary>
        /// <remarks>Get the details of a household</remarks>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        [Route("Households")]
        public async Task<Household> GetHousehold(int hhId)
        {
            return await db.GetHousehold(hhId);
        }

        /// <summary>
        /// Get a list of budgets from their HouseholdId
        /// </summary>
        /// <remarks>Get a list of Budgets in a certain household</remarks>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        [Route("Budgets")]
        public async Task<List<Budget>> GetBudgets(int hhId)
        {
            return await db.GetBudgets(hhId);
        }

        /// <summary>
        /// Get a list of transactions
        /// </summary>
        /// <remarks>Get a list of transactions in an account</remarks>
        /// <param name="accountId">Account Id</param>
        /// <returns></returns>
        [Route("Transactions")]
        public async Task<List<Transaction>> GetTransactions(int accountId)
        {
            return await db.GetTransactions(accountId);
        }

        /// <summary>
        /// Get an accounts details from its id and Household Id 
        /// </summary>
        /// <remarks>Get the details of a certain account</remarks>
        /// <param name="accountId">Account Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        [Route("AccountDetails")]
        public async Task<Account> GetAccountDetails(int accountId, int hhId)
        {
            return await db.GetAccountDetails(accountId, hhId);
        }

        /// <summary>
        /// Gets a list of all accounts
        /// </summary>
        /// <remarks>Get a list of accounts in a household</remarks>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        [Route("Accounts")]
        public async Task<List<Account>> GetAccounts(int hhId)
        {
            return await db.GetAccounts(hhId);
        }

        /// <summary>
        /// Gets the details of a single budget 
        /// </summary>
        /// <remarks>Get the details of a budget</remarks>
        /// <param name="budgetId">Budget Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        [Route("BudgetDetails")]
        public async Task<Budget> GetBudgetDetails(int budgetId, int hhId)
        {
            return await db.GetBudgetDetails(budgetId, hhId);
        }

        /// <summary>
        /// Get the details of a single budget item
        /// </summary>
        /// <remarks>Get the details of a budget item</remarks>
        /// <param name="budgetId">Budget Id</param>
        /// <param name="itemId">Budget Item Id</param>
        /// <returns></returns>
        [Route("BudgetItemDetails")]
        public async Task<BudgetItem> GetBudgetItemDetails(int budgetId, int itemId)
        {
            return await db.GetBudgetItemDetails(budgetId, itemId);
        }

        /// <summary>
        /// Get a list of all budget items
        /// </summary>
        /// <remarks>Get a list of budget items in a budget</remarks>
        /// <param name="budgetId">Budget Id</param>
        /// <returns></returns>
        [Route("BudgetItems")]
        public async Task<List<BudgetItem>> GetBudgetItems(int budgetId)
        {
            return await db.GetBudgetItems(budgetId);
        }

        /// <summary>
        /// Gets the details of as single transaction
        /// </summary>
        /// <remarks>Get the details of a transaction</remarks>
        /// <param name="transactionId">Transaction Id</param>
        /// <param name="accountId">Account Id</param>
        /// <returns></returns>
        [Route("TransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int transactionId, int accountId)
        {
            return await db.GetTransactionDetails(transactionId, accountId);
        }

        /// <summary>
        /// Add a budget to a household
        /// </summary>
        /// <remarks>Add a budget to a household</remarks>
        /// <param name="name">Budget Name</param>
        /// <param name="hhId">Household Id</param>
        /// <param name="target">Target spending</param>
        /// <returns></returns>
        [Route("AddBudget")]
        [AcceptVerbs("POST")]
        public async Task<IHttpActionResult> AddBudget(string name, int hhId, decimal target)
        {
            await db.AddBudget(name, hhId, target);
            return Ok();
        }

        /// <summary>
        /// Add an account to your household
        /// </summary>
        /// <remarks>Add an account to a household</remarks>
        /// <param name="hhId">HouseholdId</param>
        /// <param name="name">Account Name</param>
        /// <param name="balance">Account Balance</param>
        /// <returns></returns>
        [Route("AddAccount")]
        [AcceptVerbs("POST")]
        public async Task<IHttpActionResult> AddAccount(int hhId, string name, decimal balance)
        {
            await db.AddAccount(hhId, name, balance);
            return Ok();
        }

        /// <summary>
        /// Add a transaction to an account
        /// </summary>
        /// <remarks>Add a transaction to an account</remarks>
        /// <param name="accountId">Account Id</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="amount">transaction amount</param>
        /// <param name="typeId">Transaction Type Id</param>
        /// <param name="isVoid">Is this void</param>
        /// <param name="userId">User Id of who entered it</param>
        /// <returns></returns>
        [Route("AddTransaction")]
        [AcceptVerbs("POST")]
        public async Task<IHttpActionResult> AddTransaction(int accountId, string description, decimal amount, int typeId, bool isVoid, string userId, bool Reconciled)
        {
            await db.AddTransaction(accountId, description, amount, typeId, isVoid, userId, Reconciled);
            return Ok();
        }

        /// <summary>
        /// Delete a Budget
        /// </summary>
        /// <remarks>Delete a budget from a household</remarks>
        /// <param name="budgetId"> budget Id</param>
        /// <returns></returns>
        [Route("DeleteBudget")]
        [AcceptVerbs("DELETE")]
        public async Task<IHttpActionResult> DeleteBudget(int budgetId)
        {
            await db.DeleteBudget(budgetId);
            return Ok();
        }

        /// <summary>
        /// Delete an account
        /// </summary>
        /// <remarks>Delete an account from a household</remarks>
        /// <param name="accountId">account Id</param>
        /// <returns></returns>
        [Route("DeleteAccount")]
        [AcceptVerbs("DELETE")]
        public async Task<IHttpActionResult> DeleteAccount(int accountId)
        {
            await db.DeleteAccount(accountId);
            return Ok();
        }

        /// <summary>
        /// Delete a transaction
        /// </summary>
        /// <remarks>Delete a transaction from an account</remarks>
        /// <param name="transactionId">transactionId</param>
        /// <returns></returns>
        [Route("DeleteTransaction")]
        [AcceptVerbs("DELETE")]
        public async Task<IHttpActionResult> DeleteTransaction(int transactionId)
        {
            await db.DeleteTransaction(transactionId);
            return Ok();
        }
    }
}
