namespace Thegioididong.Api.Contracts.Data.Entities
{
    public interface IUserTracking
    {
        string CreatedBy { get; set; }

        string LastModifiedBy { get; set; }
    }
}
