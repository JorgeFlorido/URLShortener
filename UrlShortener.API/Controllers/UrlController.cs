using Microsoft.AspNetCore.Mvc;
using URLShortener.API.Models.Requests;
using URLShortener.API.Models.Responses;
using URLShortener.Application.Interfaces;

namespace UrlShortener.API.Controllers
{
    [ApiController]
    [Route("api/url")]
    public class UrlController : Controller
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> GetOriginalUrl(string shortUrl)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
                return BadRequest("URL cannot be empty.");

            var originalUrl = await _urlShortenerService.GetOriginalUrlAsync(shortUrl);

            if (originalUrl == null)
                return NotFound();

            var response = new GetOriginalUrlResponse
            {
                ShortUrl = shortUrl,
                OriginalUrl = originalUrl
            };

            return Ok(response);
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Url))
                return BadRequest("URL cannot be empty.");

            var shortenedUrl = await _urlShortenerService.ShortenUrlAsync(request.Url);

            var response = new ShortenUrlResponse
            {
                OriginalUrl = request.Url,
                ShortenedUrl = shortenedUrl
            };

            return Ok(response);
        }
    }
}
