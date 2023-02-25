using Microsoft.AspNetCore.DataProtection.Repositories;

namespace WebAppMVCLesson1.Admin.Models
{
    public class ProductSum
    {
        public IRepository Repository { get; set; }

        public ProductSum(IRepository repository)
        {
            Repository = repository;
        }

        public decimal Total => Repository.Products.Sum(s => s.Prise);
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Prise { get; set; }
    }

    public interface IRepository
    {
        public int Summ();
        IEnumerable<Product> Products { get; }
        Product this[string name] { get; }
        void AddProduct(Product product);
        void RemoveProduct(Product product);
    }

    public class Repository : IRepository
    {
        private Dictionary<string, Product> _products;
        private IStorage _storage;
        public Repository(IStorage storage)
        {
            _storage = storage;
            _products = new Dictionary<string, Product>();
            new List<Product>()
            {
                new Product { Name = "Women Shoes", Prise = 99M },
                new Product { Name = "Men Shoes", Prise = 29.99M },
            }.ForEach(p=>AddProduct(p));
        }

        private string guid = System.Guid.NewGuid().ToString();
        public override string ToString()
        {
            return guid;
        }

        public IEnumerable<Product> Products => _products.Values;
        public Product this[string name] => _products[name];
        //public Product this[string name]
        //{
        //    get { return _products[name]; }
        //}

        public void AddProduct(Product product)
        {
            _products[product.Name] = product;
        }
        public void RemoveProduct(Product product)
        {
            _products.Remove(product.Name);
        }
        public int Summ() { return 0; }
    }
}
