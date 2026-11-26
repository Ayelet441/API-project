using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductRepository repository;

        public ProductService(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await repository.GetAllProducts();
        }
    }
}
