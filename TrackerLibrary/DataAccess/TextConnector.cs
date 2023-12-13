using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        // name="Tournaments" connectionString= "Server=.\sql2016;Database=Tournaments; Trusted_Connection=True;" providerNeme="System.Data.SqlClient"
        // TODO - Wire up the CreatePrize for text files.
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new SqlConnection("Server=.\\DESKTOP-EGNA907\\kozak; Database=Tournaments; Trusted_Connection=True;"))
            //SqlConnection(GlobalConfig("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }      
        }
    }
}
