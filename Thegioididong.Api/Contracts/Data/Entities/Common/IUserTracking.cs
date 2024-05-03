namespace Thegioididong.Api.Contracts.Data.Entities.Common
{
    public interface IUserTracking
    {
        string CreatedBy { get; set; }

        string LastModifiedBy { get; set; }
    }
}
