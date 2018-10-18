using SIS.Framework.Attributes.Methods;

namespace SIS.Framework.Attributes
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        private const string GetMethodNameUpperCase = "GET";

        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == GetMethodNameUpperCase;
        }
    }
}