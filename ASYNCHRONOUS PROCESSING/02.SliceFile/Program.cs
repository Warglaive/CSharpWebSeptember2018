using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.SliceFile
{
    public class Program
    {
        public static void Main()
        {
            var videoPath = Console.ReadLine();
            var destinationPath = Console.ReadLine();
            var parts = int.Parse(Console.ReadLine());
            SliceAsync(videoPath, destinationPath, parts);
            Console.WriteLine("Slice complete.");
            Console.WriteLine("Anything else?");
            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destinationPath, parts);
            });
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var fileInfo = new FileInfo(sourceFile);
                var partLength = source.Length / parts + 1;
                var currentByte = 0;
                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    var filePath = string.Format($"{destinationPath}/Part-{currentPart}{fileInfo.Extension}");
                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        //
                        var buffer = new byte[partLength];
                        while (currentByte <= partLength * currentPart)
                        {
                            var readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }
        }
    }
}