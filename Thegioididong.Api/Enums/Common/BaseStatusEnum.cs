using System.Runtime.Serialization;
using Thegioididong.Api.Attributes;

namespace Thegioididong.Api.Enums.Common
{
    public enum BaseStatusEnum
    {
        [EnumMember(Value = "published")]
        Published,

        [EnumMember(Value = "draft")]
        Draft,

        [EnumMember(Value = "pending")]
        Pending,
    }
}
