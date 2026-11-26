using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        MyStorContext _dbcontext;

        public ProductRepository(MyStorContext myStorContext)
        {
            _dbcontext = myStorContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = await _dbcontext.Products.Include(p => p.Category).ToListAsync();
            return products;
        }
    }
}
