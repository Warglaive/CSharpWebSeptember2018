using SIS.Framework.Attributes.Methods;

namespace SIS.Framework.Attributes
{
    public class HttpPutAttribute : HttpMethodAttribute
    {
        private const string PutMethodNameUpperCase = "PUT";
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == PutMethodNameUpperCase;
        }
    }
}