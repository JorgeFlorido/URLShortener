using URLShortener.Domain.Models;

namespace URLShortener.Domain.Abstractions
{
    public interface IUrlRepository
    {
        public Task AddUrlMappingAsync(UrlMapping urlMapping);

        public Task<UrlMapping?> GetUrlMappingAsync(string shortenedUrl);
    }
}
