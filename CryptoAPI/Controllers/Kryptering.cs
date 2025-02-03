using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EncryptionController : ControllerBase
{
    private readonly EncryptionService _encryptionService;

    public EncryptionController()
    {
        _encryptionService = new EncryptionService();  // Instansiera EncryptionService
    }

    // POST api/encryption/encrypt
    [HttpPost("encrypt")]
    public ActionResult<string> Encrypt([FromBody] string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return BadRequest("Text must not be empty.");
        }

        var encryptedText = _encryptionService.Encrypt(text);
        return Ok(new { encrypted_text = encryptedText });
    }

    // POST api/encryption/decrypt
    [HttpPost("decrypt")]
    public ActionResult<string> Decrypt([FromBody] string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return BadRequest("Text must not be empty.");
        }

        var decryptedText = _encryptionService.Decrypt(text);
        return Ok(new { decrypted_text = decryptedText });
    }
}
