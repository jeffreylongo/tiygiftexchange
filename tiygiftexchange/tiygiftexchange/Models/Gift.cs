﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace tiygiftexchange.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public string GiftHint { get; set; }
        public string ColorWrappingPaper { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? Depth { get; set; }
        public int? Weight { get; set; }
        public bool? IsOpened { get; set; }


        public Gift() { }

        public Gift(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Contents = reader["Contents"].ToString();
            this.GiftHint = reader["GiftHint"].ToString();
            this.ColorWrappingPaper = reader["ColorWrappingPaper"].ToString();
            this.Height = reader["Height"] as int?;
            this.Width = reader["Width"] as int?;
            this.Depth = reader["Depth"] as int?;
            this.Weight = reader["Weight"] as int?;
            this.IsOpened = reader["IsOpened"] as bool?;

        }
    }
}