using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    /// <summary>
    /// Account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Household Id
        /// </summary>
        public int HouseholdId { get; set; }

        /// <summary>
        /// Account Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Account Balance
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Reconciled balance
        /// </summary>
        public int? ReconBalance { get; set; }
    }
}