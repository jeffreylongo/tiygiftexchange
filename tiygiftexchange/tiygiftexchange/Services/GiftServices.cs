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
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Contents", newGift.Contents);
                cmd.Parameters.AddWithValue("@GiftHint", newGift.GiftHint);
                cmd.Parameters.AddWithValue("@ColorWrappingPaper", newGift.ColorWrappingPaper);
                cmd.Parameters.AddWithValue("@Height", newGift.Height);
                cmd.Parameters.AddWithValue("@Width", newGift.Width);
                cmd.Parameters.AddWithValue("@Depth", newGift.Depth);
                cmd.Parameters.AddWithValue("@Weight", newGift.Weight);
                cmd.Parameters.AddWithValue("@IsOpened", newGift.IsOpened);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}