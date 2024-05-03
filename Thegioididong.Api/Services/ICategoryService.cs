using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Repositories.Interfaces;
using Thegioididong.Api.Services.Interfaces;

namespace Thegioididong.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetProductsAsync()
        {
            var result = await _repository.FindAll().ToListAsync();

            return result;
        }
    }
}
