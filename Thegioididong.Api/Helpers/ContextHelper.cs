namespace Thegioididong.Api.Helpers
{
    public static class ContextHelper
    {
        public static bool IsWriteOperation(HttpContext context)
        {
            return context.Request.Method == HttpMethods.Post ||
                   context.Request.Method == HttpMethods.Put ||
                   context.Request.Method == HttpMethods.Delete;
        }
    }
}
