using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.CoreLayer.Services.FileManager
{
    public class FileManager : IFileManager
    {
        public void DeleteFile(string fileName, string path)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public string SaveFile(IFormFile file, string savePath)
        {
            if (file == null)
                throw new Exception("فایلی وجود ندارد");
            var fileName=$"{Guid.NewGuid()}{file.FileName}";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), savePath.Replace("/","\\"));

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fullPath= Path.Combine(folderPath, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);

            file.CopyTo(stream);

            return fileName;
        }
    }
}
