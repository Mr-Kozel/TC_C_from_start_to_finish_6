using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Az adott körben szereplő csapatok.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// A győztes csapat.
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// Az adott kör azonosítója.
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
