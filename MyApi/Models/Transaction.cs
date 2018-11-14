using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    /// <summary>
    /// Transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Account Id
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Transaction Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date of transaction
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Is it reconciled
        /// </summary>
        public bool Reconciled { get; set; }

        /// <summary>
        /// Reconciled Amount
        /// </summary>
        public decimal? ReconAmount { get; set; }

        /// <summary>
        /// Id of who entered it 
        /// </summary>
        public string EnteredByUserId { get; set; }

        /// <summary>
        /// Transaction type Id
        /// </summary>
        public int TransactionTypeId { get; set; }

        /// <summary>
        /// Budget Item Id
        /// </summary>
        public int? BudgetItemId { get; set; }

        /// <summary>
        /// Is it void
        /// </summary>
        public bool Void { get; set; }
    }
}