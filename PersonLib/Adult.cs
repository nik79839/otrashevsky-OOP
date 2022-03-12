using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class Adult : PersonBase
    {
        /// <summary>
        /// Passport data
        /// </summary>
        private string _passport;

        /// <summary>
        /// Spouse
        /// </summary>
        private Adult _spouse;

        /// <summary>
        /// Information about job
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Marital status
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// Passport data
        /// </summary>
        public string Passport 
        { 
            get 
            { 
                return _passport;
            } 
            set
            { 
                _passport = value;
            }
        }

        public Adult Spouse
        {
            get
            {
                return _spouse;
            }
            set
            {
                _spouse = value;
            }
        }

        public override string Info()
        {
            string personInfo=$"{base.Info()}, Passport: {Passport}, +" +
                $"Marital status: {MaritalStatus}";
            return personInfo;
        }

    }
}
