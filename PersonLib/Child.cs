using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Child person
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Father
        /// </summary>
        public Adult Father { get; set; }

        /// <summary>
        /// Mother
        /// </summary>
        public Adult Mother { get; set; }

        /// <summary>
        /// Name of school or kindergarten
        /// </summary>
        public string School { get; set; }
    }
}
