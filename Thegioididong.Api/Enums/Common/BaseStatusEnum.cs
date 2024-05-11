using System.Runtime.Serialization;
using Thegioididong.Api.Attributes;

namespace Thegioididong.Api.Enums.Common
{
    public enum BaseStatusEnum
    {
        [EnumMember(Value = "published")]
        Published = 1,

        [EnumMember(Value = "draft")]
        Draft = 2,

        [EnumMember(Value = "pending")]
        Pending = 3,
    }
}
