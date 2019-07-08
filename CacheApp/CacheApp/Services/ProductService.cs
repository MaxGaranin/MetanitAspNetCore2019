using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CacheApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace CacheApp.Services
{
    public class ProductService
    {
        private readonly MobileContext _db;
        private readonly IMemoryCache _cache;

        public ProductService(MobileContext context, IMemoryCache memoryCache)
        {
            _db = context;
            _cache = memoryCache;
        }

        public void Initialize()
        {
            if (!_db.Products.Any())
            {
                _db.Products.AddRange(
                    new Product {Name = "iPhone 8", Company = "Apple", Price = 600},
                    new Product {Name = "Galaxy S9", Company = "Samsung", Price = 550},
                    new Product {Name = "Pixel 2", Company = "Google", Price = 500}
                );
                _db.SaveChanges();
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            int n = _db.SaveChanges();
            if (n > 0)
            {
                _cache.Set(product.Id, product, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = null;
            if (!_cache.TryGetValue(id, out product))
            {
                product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    _cache.Set(product.Id, product,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }

            return product;
        }
    }
}