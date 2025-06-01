using Microsoft.AspNetCore.Mvc;

namespace EncriptadorCesarApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : ControllerBase
    {
        [HttpPost]
        public IActionResult Encrypt([FromBody] EncryptRequest request)
        {
            string encrypted = CaesarEncrypt(request.Message, request.Shift);
            return Ok(new { EncryptedMessage = encrypted });
        }

        private string CaesarEncrypt(string text, int shift)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char c = buffer[i];
                if (char.IsLetter(c))
                {
                    char d = char.IsUpper(c) ? 'A' : 'a';
                    buffer[i] = (char)(((c + shift - d) % 26) + d);
                }
            }
            return new string(buffer);
        }
    }

    public class EncryptRequest
    {
        public string Message { get; set; }
        public int Shift { get; set; }
    }
}
