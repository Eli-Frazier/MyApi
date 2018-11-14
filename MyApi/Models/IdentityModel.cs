using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection")
        { }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        //call a sql stored procedure
        public async Task<Household> GetHousehold(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHousehold @hhId",
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgets(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="hhId"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public async Task<int> AddBudget(string Name, int hhId, decimal target)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @name, @hhId, @trgt",
                new SqlParameter("name", Name),
                new SqlParameter("hhId", hhId),
                new SqlParameter("trgt", target));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public async Task<int> AddAccount(int hhId, string name, decimal balance)
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @hhId, @name, @balance",
                new SqlParameter("hhId", hhId),
                new SqlParameter("name", name),
                new SqlParameter("balance", balance));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="description"></param>
        /// <param name="amount"></param>
        /// <param name="typeId"></param>
        /// <param name="isVoid"></param>
        /// <param name="userId"></param>
        /// <param name="Reconciled"></param>
        /// <returns></returns>
        public async Task<int> AddTransaction(int accountId, string description, decimal amount, int typeId, bool isVoid, string userId, bool Reconciled)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @acctId, @desc, @amnt, @type, @isVoid, @user, @recon",
                new SqlParameter("acctId", accountId),
                new SqlParameter("desc", description),
                new SqlParameter("amnt", amount),
                new SqlParameter("type", typeId),
                new SqlParameter("isVoid", isVoid),
                new SqlParameter("user", userId),
                new SqlParameter("recon", Reconciled));
        }

        /// <summary>
        /// Gets Transactions by Account Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactions(int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @acctId",
                new SqlParameter("acctId", accountId)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountDetails(int accountId, int hhId)
        {
            return await Database.SqlQuery<Account>("GetAccountDetails @acctId, @hhId",
                new SqlParameter("acctId", accountId),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<Account>> GetAccounts(int hhId)
        {
            return await Database.SqlQuery<Account>("GetAccounts @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<Budget> GetBudgetDetails(int budgetId, int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @bdgtId, @hhId",
                new SqlParameter("bdgtId", budgetId),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<BudgetItem> GetBudgetItemDetails(int budgetId, int itemId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @bdgtId, @itemId",
                new SqlParameter("bdgtId", budgetId),
                new SqlParameter("itemId", itemId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public async Task<List<BudgetItem>> GetBudgetItems(int budgetId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @bdgtId",
                new SqlParameter("bdgtId", budgetId)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetails(int transactionId, int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @trxId, @acctId",
                new SqlParameter("trxId", transactionId),
                new SqlParameter("acctId", accountId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public async Task<int> DeleteBudget(int budgetId)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteBudget @bdgtId",
                new SqlParameter("bdgtId", budgetId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<int> DeleteAccount(int accountId)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteAccount @acctId",
                new SqlParameter("acctId", accountId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public async Task<int> DeleteTransaction(int transactionId)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteTransaction @trnsId",
                new SqlParameter("trnsId", transactionId));
        }
    }
}