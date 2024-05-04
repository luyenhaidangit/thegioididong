namespace Thegioididong.Api.Contracts.Data.Entities.Location
{
    public abstract class Translatable : ITranslatable
    {
        public string LangCode { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
