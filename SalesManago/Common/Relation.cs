using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public enum Relationtype
    {
        CHILD,
        PARENT
    }

    public class Relation
    {
        /// <summary>
        /// relation type
        /// </summary>
        public Relationtype Type { get; set; }

        /// <summary>
        /// e-mail of the contact with whom the relationship is to be created,
        /// the given contact must already exist in the system
        /// </summary>
        public string Email { get; set; }
    }
}