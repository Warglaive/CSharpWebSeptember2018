using System.IO;
using SIS.Framework.ActionResults;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        public View(string fullyQualifiedTemplateName)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }
        //may have bug
        private string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            var content = File.ReadAllText(filePath);
            return content;
        }
        public string Render()
        {
            var fullHtml = this.ReadFile(this.fullyQualifiedTemplateName);
            return fullHtml;
        }
    }
}