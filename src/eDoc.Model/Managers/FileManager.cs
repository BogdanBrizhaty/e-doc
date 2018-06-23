using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileOptions = eDoc.Model.Common.Enums.FileOptions;

namespace eDoc.Model.Managers
{
    public class TextFileManager : IFileManager<string, Encoding>
    {
        private Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        public TextFileManager()
        {
        }
        public TextFileManager(Encoding defaultEncoding)
        {
            _defaultEncoding = defaultEncoding;
        }

        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public async Task<string> GetContent(string filePath)
        {
            return await GetContent(filePath, _defaultEncoding);
        }

        public async Task<string> GetContent(string filePath, Encoding encoding)
        {
            string content;
            using (var stream = new StreamReader(filePath, encoding))
            {
                content = await stream.ReadToEndAsync();
                stream.Close();
            }
            return content;
        }

        public FileStream GetContentStream(string filePath)
        {
            return File.OpenRead(filePath);
        }

        public async Task WriteContent(string filePath, string content, FileOptions options = FileOptions.Append)
        {
            await WriteContent(filePath, content, _defaultEncoding, options);
        }

        public async Task WriteContent(string filePath, string content, Encoding option, FileOptions options = FileOptions.Append)
        {
            if (!options.HasFlag(FileOptions.CreateIfNotExists) && !Exists(filePath))
                throw new FileNotFoundException($"File {filePath} was not found. Add file or use FileOptions.CreateIfNotExist option");

            using (var writer = new StreamWriter(filePath, options.HasFlag(FileOptions.Append), option))
            {
                await writer.WriteAsync(content);
                writer.Close();
            }
        }
    }
}
