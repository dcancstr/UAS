using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Storage.Azure;
using UAS.EnvironmentConfiguration;

namespace UAS.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }
        public async Task DeleteAsync(string logoUrl, string layoutImageUrl, string siteName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(logoUrl);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(siteName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string logoUrl)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(logoUrl);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string logoUrl, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(logoUrl);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<List<(string siteName, string logoUrl, string layoutImageUrl)>> UploadAsync(string logoUrl, string layoutImageUrl, IFormFile logo, IFormFile layoutImage)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(logoUrl);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string siteName, string logoUrl, string layoutImageUrl)> datas = new();

            BlobClient blobClient = _blobContainerClient.GetBlobClient(logo.Name);
            await blobClient.UploadAsync(logo.OpenReadStream());
            await blobClient.UploadAsync(layoutImage.OpenReadStream());
            datas.Add((logo.Name, $"{logoUrl}\\{logo.FileName}", $"{layoutImageUrl}\\{layoutImage.FileName}"));

            return datas;
        }
    }
}
