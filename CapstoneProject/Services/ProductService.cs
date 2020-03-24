using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject.Models;

namespace CapstoneProject.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(ICapstoneDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.CapstoneCollectionName);
        }

        public List<Product> Get() =>
            _products.Find(products => true).ToList();

        public Product Get(string id) =>
            _products.Find<Product>(product => product.Id == id).FirstOrDefault();

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product prodIn) =>
            _products.ReplaceOne(product => product.Id == id, prodIn);

        //public void Remove(Book bookIn) =>
        //    _books.DeleteOne(book => book.Id == bookIn.Id);

        //public void Remove(string id) =>
        //    _books.DeleteOne(book => book.Id == id);
    }
}
