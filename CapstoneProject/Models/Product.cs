using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CapstoneProject.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("type")]
        [Required]
        public string Type { get; set; }

        [BsonElement("description")]
        [Required]
        public string Description { get; set; }

        [BsonElement("price")]
        [Required]
        public double Price { get; set; }

        [BsonElement("diet")]
        [Required]
        public string DietaryRestrictions { get; set; }

        [BsonElement("amountQty")]
        [Required]
        public string AmountQty { get; set; }

        [BsonElement("minorder")]
        [Required]
        public int MinProductOrderPoint { get; set; }


        [BsonElement("ImageUrl")]
        [Display(Name = "photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }

        [BsonElement("visibility")]
        public bool isVisable { get; set; }
    }
}
