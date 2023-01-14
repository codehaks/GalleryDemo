using Microsoft.AspNetCore.Mvc;

namespace GalleryDemo.Controllers;

public class PicController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public PicController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [Route("api/pic/{**fileName}")]
    public IActionResult Get(string fileName)
    {
        var picPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Pictures",fileName);
        var fileContent=System.IO.File.ReadAllBytes(picPath);
        return File(fileContent,"image/jpeg");
    }
}
