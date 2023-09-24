namespace URLShortening.DAL.Entity
{
    public class ShortenedUrl
    {
        public long Id { get; set; }
        public string LongUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
