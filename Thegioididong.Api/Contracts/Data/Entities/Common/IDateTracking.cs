namespace Thegioididong.Api.Contracts.Data.Entities.Common
{
    public interface IDateTracking
    {
        //DateTimeOffset CreatedDate { get; set; }

        //DateTimeOffset? LastModifiedDate { get; set; }

        DateTimeOffset? CreatedAt { get; set; }

        DateTimeOffset? UpdatedAt { get; set; }
    }
}
