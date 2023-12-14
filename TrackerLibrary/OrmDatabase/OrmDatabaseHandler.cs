using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.OrmDatabase
{
    public class OrmDatabaseHandler
    {
        private readonly OrmDatabaseContext _db;

        public OrmDatabaseHandler(OrmDatabaseContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public List<PrizeModel> GetPrizes()
        {
            var prizes = _db.PrizeTable.ToList();
            return prizes;
        }
        public void AddNewPrize(PrizeModel modelToAdd)
        {
            _db.PrizeTable.Add(modelToAdd);
            _db.SaveChanges();
        }

        public bool DeletePrizeById(int id)
        {
            PrizeModel prizeToDelete = _db.PrizeTable.FirstOrDefault(x => x.Id == id);
            if(prizeToDelete != null)
            {
                _db.PrizeTable.Remove(prizeToDelete);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
