using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dapper_Project.Models
{
    public class ProductModel
    {
        [Column("id")]
        public int Product_id {  get; set; }
        [Column("product_name")]
        public string Product_Name { get; set; }
        [Column("product_description")]
        public string Product_Description { get; set; }
        [Column("created_at")]
        public DateTime Create_dateTime { get; set; } = DateTime.Now;

        


    }
}