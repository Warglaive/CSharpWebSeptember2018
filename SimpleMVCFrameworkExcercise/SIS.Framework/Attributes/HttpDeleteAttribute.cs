using SIS.Framework.Attributes.Methods;

namespace SIS.Framework.Attributes
{
    public class HttpDeleteAttribute : HttpMethodAttribute
    {
        private const string DeleteMethodNameUpperCase = "DELETE";
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == DeleteMethodNameUpperCase;
        }
    }
}