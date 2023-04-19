using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string siteName, string logoUrl, string layoutImageUrl)>> UploadAsync(string logoUrl, string layoutImageUrl, IFormFile logo, IFormFile layoutImage);
        Task DeleteAsync(string logoUrl, string layoutImageUrl, string fileName);
        List<string> GetFiles(string logoUrl);
        bool HasFile(string logoUrl, string fileName);
    }
}
