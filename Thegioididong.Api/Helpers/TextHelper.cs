using System.Text.RegularExpressions;

namespace Thegioididong.Api.Helpers
{
    public static class TextHelper
    {
        public static string ConvertToSlug(string title)
        {
            var slug = title.ToLower();

            slug = Regex.Replace(slug, @"á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ", "a");
            slug = Regex.Replace(slug, @"é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ", "e");
            slug = Regex.Replace(slug, @"i|í|ì|ỉ|ĩ|ị", "i");
            slug = Regex.Replace(slug, @"ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ", "o");
            slug = Regex.Replace(slug, @"ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự", "u");
            slug = Regex.Replace(slug, @"ý|ỳ|ỷ|ỹ|ỵ", "y");
            slug = Regex.Replace(slug, @"đ", "d");
            slug = Regex.Replace(slug, @"`|~|!|@|#|\||\$|%|\^|&|\*|\(|\)|\+|=|,|\.|/|\?|>|<|'|\"":|;|_", "");
            slug = Regex.Replace(slug, " ", "-");
            slug = Regex.Replace(slug, @"\-{5}", "-");
            slug = Regex.Replace(slug, @"\-{4}", "-");
            slug = Regex.Replace(slug, @"\-{3}", "-");
            slug = Regex.Replace(slug, @"\-{2}", "-");
            slug = "@" + slug + "@";
            slug = Regex.Replace(slug, @"\@\-|\-\@|\@", "");

            return slug;
        }
    }
}
