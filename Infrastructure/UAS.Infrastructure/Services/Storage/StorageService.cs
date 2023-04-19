using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Storage;

namespace UAS.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }


        public async Task DeleteAsync(string logoUrl, string layoutImageUrl, string fileName)
        {
            await _storage.DeleteAsync(logoUrl, layoutImageUrl, fileName);
        }


        public List<string> GetFiles(string logoUrl)
       => _storage.GetFiles(logoUrl);

        public bool HasFile(string logoUrl, string fileName)
      => _storage.HasFile(logoUrl, fileName);

        public Task<List<(string siteName, string logoUrl, string layoutImageUrl)>> UploadAsync(string logoUrl, string layoutImageUrl, IFormFile logo, IFormFile layoutImage)
        => _storage.UploadAsync(logoUrl, layoutImageUrl, logo, layoutImage);
    }
}
