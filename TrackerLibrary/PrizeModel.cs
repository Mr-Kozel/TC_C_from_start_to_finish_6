using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Hanyadik helyen végzett.
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// Helyezés.
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// Nyeremény nagysága.
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// Nyeremény százalékos eloszlása.
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
