using Microsoft.AspNetCore.Http;

namespace Contract;

public class Image
{
    public required IFormFile File { get; set; }
}