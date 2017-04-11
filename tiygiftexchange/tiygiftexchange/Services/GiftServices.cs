using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using tiygiftexchange.Models;

namespace tiygiftexchange.Services
{
    public class GiftServices
    {
        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=GiftExchange;Trusted_Connection=True;";
        public List<Gift> GetAllGifts()
        {
            var rv = new List<Gift>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM GiftTable";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Gift(reader));
                }
                return rv;
            }
        }
        
        public void AddGift(Gift newGift)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO GiftTable ([Contents], [GiftHint], [ColorWrappingPaper], " +
                    "[Height], [Width], [Depth], [Weight], [IsOpened]) " +
                    "VALUES(@Contents, @GiftHint, @ColorWrappingPaper, @Height, @Width, @Depth, @Weight, @IsOpened)";
            }
        }
    }
}