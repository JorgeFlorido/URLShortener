using Microsoft.EntityFrameworkCore;
using URLShortener.Domain.Abstractions;
using URLShortener.Domain.Models;

namespace URLShortener.Database.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlShortenerDbContext _context;

        public UrlRepository(UrlShortenerDbContext context)
        {
            _context = context;
        }

        public async Task AddUrlMappingAsync(UrlMapping urlMapping)
        {
            _context.UrlMappings.Add(urlMapping);
            await _context.SaveChangesAsync();
        }

        public async Task<UrlMapping?> GetUrlMappingAsync(string shortenedUrl)
        {
            return await _context.UrlMappings
                .FirstOrDefaultAsync(u => u.ShortenedUrl == shortenedUrl);
        }
    }
}
