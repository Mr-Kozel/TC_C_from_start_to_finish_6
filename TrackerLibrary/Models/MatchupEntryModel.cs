using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Egy csapat a játékban.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Az adott csapat pontjai.
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Az a meccs, ahonnan az adott csapat győztesként került ki.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
