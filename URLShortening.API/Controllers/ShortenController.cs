using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using URLShortening.API.Request;
using URLShortening.DAL;
using URLShortening.DAL.Entity;
using URLShortening.Service;

namespace URLShortening.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortenController : ControllerBase
    {
        private readonly URLContext _context;
        private readonly UrlShorteningService _service;

        public ShortenController(URLContext context, UrlShorteningService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet("GetUrl")]
        public async Task<IActionResult> Get([FromQuery] RedirectUrlRequest request)
        {
            try
            {
                _service.CheckUrl(request.ShortUrl);

                var shortenedUrl = await _context.ShortenedUrl.FirstOrDefaultAsync(x => x.ShortUrl == request.ShortUrl);

                if (shortenedUrl is null)
                    return NotFound("Short url cannot found");

                return Redirect(shortenedUrl.LongUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("CreateShortUrl")]
        public async Task<IActionResult> CreateShortUrl([FromBody] URLRequest request)
        {
            try
            {
                _service.CheckUrl(request.URL);

                var code = request.CustomUrlShortCode;

                if (string.IsNullOrEmpty(request.CustomUrlShortCode))
                    code = await _service.GenerateUrlCode();

                var convertedUrl = _service.ConvertUrl(request.URL);

                var shortenedUrl = new ShortenedUrl
                {
                    LongUrl = request.URL,
                    ShortUrl = $"{convertedUrl}/{code}",
                    Code = code,
                    CreatedDate = DateTime.Now
                };

                _context.ShortenedUrl.Add(shortenedUrl);

                await _context.SaveChangesAsync();

                return Ok(new { shortenedUrl.ShortUrl, Message = "Short URL created successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
