using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// A játékos keresztneve.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// A játékos vezetékneve.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// A játékos e-mail címe.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// A játékos telefonszáma.
        /// </summary>
        public string CellPhoneNumber { get; set; }
    }
}
