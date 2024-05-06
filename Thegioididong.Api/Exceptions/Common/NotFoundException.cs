using System.Net;

namespace Thegioididong.Api.Exceptions.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
