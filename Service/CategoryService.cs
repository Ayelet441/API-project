using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository repository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.repository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await repository.GetAllCategories();
        }
    }
}
