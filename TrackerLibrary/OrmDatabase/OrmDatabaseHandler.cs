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
        //Ez egy elég általános megoldás, arra hogy függőséget tárolj egy osztályban,
        //readonly mert mi csak egy meglévő példányt kapunk, azt csak felhasználjuk, nem módosítjuk
        //Ez általában a konstruktorból jön, ezt hívjuk Dependency Injection-nek, később fontos lesz webappoknál
        private readonly OrmDatabaseContext _db;

        public OrmDatabaseHandler(OrmDatabaseContext db)
        {
            //Dependency injection
            _db = db;
            //Ez a sor azt csinálja, ha még nem létezik az adatbázis az MSSQL ben, akkor létrehozza neked
            _db.Database.EnsureCreated();
        }

        public List<PrizeModel> GetPrizes()
        {
            //A prize tábla minden elemét mint egy List<PrizeModel> példány, vissza adja neked
            var prizes = _db.PrizeTable.ToList();
            return prizes;
        }
        public void AddNewPrize(PrizeModel modelToAdd)
        {
            //Hozzáad egy elemet a Prize tábládhoz, az ORM miatt úgy viselkedik a táblád mintha egy lista lenne
            _db.PrizeTable.Add(modelToAdd);
            //Az hogy hozzá adod, még csak a memóriában tárolja a változást, ez a metódus készíti el az SQL Query-t
            //Megnézi a változásokat az előző mentés óta, és azalapján elkészíti a Queryket (insert, delete, stb) és elküldi
            _db.SaveChanges();
        }

        public bool DeletePrizeById(int id)
        {
            //Ez egy LINQ utasítás egy lamda kifejezéssel.
            //Nagyon gyakran használt megoldás a .NET ben arra hogy tömbökön/listákon hajts végre utasítást
            //Ez pl azt csinálja, hogy egy feltétel alapján megkeresi az első elemet amire ez teljesül,
            //Ha egyikre sem teljesül, null-al tér vissza
            PrizeModel prizeToDelete = _db.PrizeTable.FirstOrDefault(x => x.Id == id);
            //Itt megnézzük hogy megtalálta-e a keresett elemet a megadott ID -vel
            if(prizeToDelete != null)
            {
                //Ha igen töröljük és visszatérünk TRUE val
                _db.PrizeTable.Remove(prizeToDelete);
                _db.SaveChanges();
                return true;
            }
            else
            {
                //Ha nem találja meg visszatérünk FALSE-al,
                //ez azért jó, mert így ahonnan meghívod, tudni fogod hogy sikerült vagy nem
                //Pl kiírhatod üzenetként ennek fügvényében hogy SIKER vagy BUKÁS
                return false;
            }
        }
    }
}
