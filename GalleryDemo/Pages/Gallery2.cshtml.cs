using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace GalleryDemo.Pages;

public class Gallery2Model : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMemoryCache _memoryCache;
    public Gallery2Model(IWebHostEnvironment webHostEnvironment, IMemoryCache memoryCache)
    {
        _webHostEnvironment = webHostEnvironment;
        _memoryCache = memoryCache;
    }

    public IList<string> FileList { get; set; }
    public void OnGet()
    {
        if(_memoryCache.TryGetValue("pics",out IList<string> cachedPics) == false) { 

        var picPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Pictures");
        var files = Directory.GetFiles(picPath).ToList();
        FileList = new List<string>();
        const string imageBase64 = "data:image/jpg;base64,";

        foreach (var file in files)
        {
            FileList.Add(imageBase64+Convert.ToBase64String(System.IO.File.ReadAllBytes(file)));
        }

            var cacheEntryOptions = new MemoryCacheEntryOptions()
              .SetSlidingExpiration(TimeSpan.FromSeconds(30));

            _memoryCache.Set("pics", FileList, cacheEntryOptions);
        }
        else
        {
            FileList = cachedPics;

        }
    }
}
