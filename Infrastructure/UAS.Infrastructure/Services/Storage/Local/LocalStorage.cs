using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Storage.Local;

namespace UAS.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMemoryCache memoryCache;

        public LocalStorage(IWebHostEnvironment webHostEnvironment, IMemoryCache memoryCache)
        {
            _webHostEnvironment = webHostEnvironment;
            this.memoryCache = memoryCache;
        }
        public async Task DeleteAsync(string logoUrl, string layoutImageUrl, string siteName)
        {
            string deletePath = Path.Combine(_webHostEnvironment.WebRootPath, logoUrl);
            string deletePath2 = Path.Combine(_webHostEnvironment.WebRootPath, layoutImageUrl);          
            File.Delete($"{deletePath}");
            File.Delete($"{deletePath2}");
        }


        public List<string> GetFiles(string logoUrl)
        {
            DirectoryInfo directory = new(logoUrl);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string logoUrl, string fileName)
        => File.Exists($"{logoUrl}\\{fileName}");
        async Task<bool> CopyFileAsync(string filePath, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            { 

                throw ex;
            }
        }

        public async Task<List<(string siteName, string logoUrl, string layoutImageUrl)>> UploadAsync(string logoUrl, string layoutImageUrl, IFormFile logo, IFormFile layoutImage)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, logoUrl);
            string uploadPath2 = Path.Combine(_webHostEnvironment.WebRootPath, layoutImageUrl);
            if (!Directory.Exists(uploadPath) && !Directory.Exists(uploadPath2))
            {
                Directory.CreateDirectory(uploadPath);
                Directory.CreateDirectory(uploadPath2);
            }
            List<(string fileName, string logoUrl, string layoutImageUrl)> datas = new();


            await CopyFileAsync($"{uploadPath}\\{logo.FileName}", logo);
            await CopyFileAsync($"{uploadPath2}\\{layoutImage.FileName}", layoutImage);


            datas.Add((logo.Name, $"{logoUrl}\\{logo.FileName}", $"{layoutImageUrl}\\{layoutImage.FileName}"));


            
            return datas;
        }
    }
}
