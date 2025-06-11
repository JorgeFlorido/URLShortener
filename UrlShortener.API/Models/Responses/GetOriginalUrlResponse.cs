namespace URLShortener.API.Models.Responses
{
    public class GetOriginalUrlResponse
    {
        public string ShortUrl { get; set; } = string.Empty;
        public string OriginalUrl { get; set; } = string.Empty;
    }
}