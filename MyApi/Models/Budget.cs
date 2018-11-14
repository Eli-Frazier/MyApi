using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    /// <summary>
    /// Budget
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// Budget Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Budget Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Household Id
        /// </summary>
        public int HouseholdId { get; set; }

        /// <summary>
        /// Target Spending 
        /// </summary>
        public decimal Target { get; set; }

        /// <summary>
        /// Current Balance
        /// </summary>
        public decimal CurrentBalance { get; set; }
    }
}