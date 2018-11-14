using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    /// <summary>
    /// Budget Item
    /// </summary>
    public class BudgetItem
    {
        /// <summary>
        /// Budget Item Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Budget Id
        /// </summary>
        public int BudgetId { get; set; }

        /// <summary>
        /// Target spending for item
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Item Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is it deleted
        /// </summary>
        public bool Deleted { get; set; }
    }    
}