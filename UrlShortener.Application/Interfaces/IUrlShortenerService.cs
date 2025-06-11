namespace URLShortener.Application.Interfaces
{
    public interface IUrlShortenerService
    {
        public Task<string> ShortenUrlAsync(string originalUrl);

        public Task<string?> GetOriginalUrlAsync(string shortUrl);
    }
}
