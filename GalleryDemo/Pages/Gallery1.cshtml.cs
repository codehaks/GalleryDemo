using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GalleryDemo.Pages;

public class Gallery1Model : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public Gallery1Model(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public IList<string> FileList { get; set; }
    public void OnGet()
    {
        var picPath= Path.Combine(_webHostEnvironment.ContentRootPath,"Pictures");
        var files = Directory.GetFiles(picPath).ToList();
        FileList = new List<string>();
        foreach (var file in files)
        {
            FileList.Add(new FileInfo(file).Name);
        }
    }
}
