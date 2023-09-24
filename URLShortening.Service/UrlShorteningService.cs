using System.Text;
using URLShortening.DAL.Parameters;
using URLShortening.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using URLShortening.Service.Exceptions;
using URLShortening.DAL.Entity;

namespace URLShortening.Service
{
    public class UrlShorteningService
    {
        private readonly URLContext _context;
        private readonly Random _random = new ();

        public UrlShorteningService(URLContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateUrlCode()
        {  
            var code = new StringBuilder();

            while(true)
            {
                for (int i = 0; i < ConstantParameters.MaxCharHashLength; i++)
                {
                    //Getting a random char from the codeSource 
                    int index = _random.Next(ConstantParameters.CodeSource.Length);
                    code.Append(ConstantParameters.CodeSource[index]);
                }

                if (!await _context.ShortenedUrl.AnyAsync(x => x.Code == code.ToString()))
                    return code.ToString();
            }
        }

        public async Task<ShortenedUrl> IsURLExistFromShortUrl(string url)
        {
            return await _context.ShortenedUrl.FirstOrDefaultAsync(x => x.LongUrl == url);
            
        }

        public string ConvertUrl(string url)
        {
            Uri uri = new Uri(url);
            string domain = uri.Host.Replace("www.", "");

            // Removing the extension (such as .com, .net) on the domain
            int dotIndex = domain.LastIndexOf('.');
            domain = domain.Substring(0, dotIndex);
            domain = domain.Replace('-', '.');

            return $"http://{domain}";
        }

        public void CheckUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new UrlValidationException("The short url is invalid");

            if (!Uri.TryCreate(url, UriKind.Absolute, out _))
                throw new UrlValidationException("The url is invalid.");

        }
    }
}