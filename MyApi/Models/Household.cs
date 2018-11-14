using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    /// <summary>
    /// Household
    /// </summary>
    public class Household
    {
        /// <summary>
        /// Household Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Household Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is the household condemned
        /// </summary>
        public bool condemned { get; set; }
    }
}