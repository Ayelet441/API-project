using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        MyStorContext _dbcontext;

        public CategoryRepository(MyStorContext myStorContext)
        {
            _dbcontext = myStorContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> categories = await _dbcontext.Categories.Include(c => c.Products).ToListAsync();
            return categories;
        }
    }
}
