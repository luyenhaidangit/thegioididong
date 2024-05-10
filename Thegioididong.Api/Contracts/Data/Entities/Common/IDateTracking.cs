namespace Thegioididong.Api.Contracts.Data.Entities.Common
{
    public interface IDateTracking
    {
        //DateTimeOffset CreatedDate { get; set; }

        //DateTimeOffset? LastModifiedDate { get; set; }

        DateTime? CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}
