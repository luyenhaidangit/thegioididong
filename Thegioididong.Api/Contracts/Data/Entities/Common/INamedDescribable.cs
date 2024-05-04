namespace Thegioididong.Api.Contracts.Data.Entities.Common
{
    public interface INamedDescribable
    {
        string? Name { get; set; }

        string? Description { get; set; }
    }
}
