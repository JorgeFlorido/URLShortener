namespace URLShortener.API.Models.Responses
{
    public class ShortenUrlResponse
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortenedUrl { get; set; } = string.Empty;
    }
}
