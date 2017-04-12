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
        //get all gifts method
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
        //add new gift method
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
        //edit gift method
        public void EditGift(Gift gift)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = @"UPDATE GiftTable SET
                [Contents] = @Contents
                ,[GiftHint] = @GiftHint
                ,[ColorWrappingPaper] = @ColorWrappingPaper
                ,[Height] = @Height
                ,[Width] = @Width
                ,[Depth] = @Depth
                ,[Weight] = @Weight
                ,[IsOpened] = @IsOpened
                WHERE Id = @Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Contents", gift.Contents);
                cmd.Parameters.AddWithValue("@GiftHint", gift.GiftHint);
                cmd.Parameters.AddWithValue("@ColorWrappingPaper", gift.ColorWrappingPaper);
                cmd.Parameters.AddWithValue("@Height", gift.Height);
                cmd.Parameters.AddWithValue("@Width", gift.Width);
                cmd.Parameters.AddWithValue("@Depth", gift.Depth);
                cmd.Parameters.AddWithValue("@Weight", gift.Weight);
                cmd.Parameters.AddWithValue("@IsOpened", gift.IsOpened);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        //delete gift method
        public void DeleteGift(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("DELETE FROM GiftTable WHERE ID=@Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }


        }

    }
}