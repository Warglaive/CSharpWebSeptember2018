using SIS.Framework.Attributes.Methods;

namespace SIS.Framework.Attributes
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        private const string PostMethodNameUpperCase = "POST";

        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == PostMethodNameUpperCase;
        }
    }
}