using Microsoft.AspNetCore.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DicleAcademyV2
{
    public class DeleteFiles
    {
        public void DeleteFile(IWebHostEnvironment webHostEnvironment , string image)
        {
            var url = webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Society\\images\\");
            string path = Path.Combine(url, image);
            System.IO.File.Delete(path);
        }
    }
}
