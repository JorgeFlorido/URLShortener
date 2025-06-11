using URLShortener.Application.Interfaces;
using URLShortener.Domain.Abstractions;
using URLShortener.Domain.Models;

namespace URLShortener.Application.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlShortenerService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<string?> GetOriginalUrlAsync(string shortCode)
        {
            var urlMapping = await _urlRepository.GetUrlMappingAsync(shortCode);
            return urlMapping?.OriginalUrl;
        }

        public async Task<string> ShortenUrlAsync(string originalUrl)
        {
            string shortCode = GenerateShortCode(originalUrl);

            var urlMapping = new UrlMapping
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = shortCode
            };

            await _urlRepository.AddUrlMappingAsync(urlMapping);
            return shortCode;
        }

        private static string GenerateShortCode(string originalUrl)
        {
            return originalUrl
                .GetHashCode()
                .ToString("X")[..6];
        }
    }
}
