using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using eDoc.Model.Common.Enums;
using System.Text;
using System.Threading.Tasks;
using FileOptions = eDoc.Model.Common.Enums.FileOptions;

namespace eDoc.Model.Managers
{
    public interface IFileManager<TContentType, TOption>
    {
        FileStream GetContentStream(string filePath);
        Task<TContentType> GetContent(string filePath);
        Task<TContentType> GetContent(string filePath, TOption option);
        Task WriteContent(string filePath, TContentType content, FileOptions options = FileOptions.Append);
        Task WriteContent(string filePath, TContentType content, TOption option, FileOptions options = FileOptions.Append);
        bool Exists(string filePath);
    }
}
