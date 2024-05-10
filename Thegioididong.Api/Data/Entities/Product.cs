using System.ComponentModel.DataAnnotations.Schema;
using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class Product : EntityAuditBase<int>
    {
        public int ProductCategoryId { get; set; }

        #region Relationship
        #endregion
    }
}
