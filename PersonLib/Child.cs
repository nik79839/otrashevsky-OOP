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
        /// Maximum age
        /// </summary>
        private const int MaxAge = 17;

        /// <summary>
        /// Minimum age
        /// </summary>
        private const int MinAge = 0;

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
        
        /// <summary>
        /// Info about child
        /// </summary>
        /// <returns>Info</returns>
        public override string Info()
        {
            string personInfo = base.InfoPerson();
            if (Father != null)
            {
                personInfo+=$", {Father.Name}";
            }
            if (Mother != null)
            {
                personInfo += $", {Mother.Name}";
            }
            if (Father==null && Mother!=null)
            {
                personInfo += $", Orphan";
            }
            if (School!=null)
            {
                personInfo += $", {School}";
            }
            return personInfo;
        }


        public static Child GetRandomChild()
        {

        }
    }
}
