using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetProductsAsync();
    }
}
