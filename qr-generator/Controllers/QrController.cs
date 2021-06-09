using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class QrController : ControllerBase
{
    private readonly ILogger<QrController> _logger;

    public QrController(ILogger<QrController> logger)
    {
        _logger = logger;
    }


    [HttpGet("generate/{data}")]
    public IActionResult GetByUrl([FromRoute] string data) 
        => string.IsNullOrEmpty(data) 
            ? BadRequest("No data given") 
            : File(QrCodeGenerator.GenerateByteArray(data), "image/jpeg");
}
