using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FileController : Controller
    {
        UploadFiles uploadFiles = new UploadFiles();
        DeleteFiles deleteFiles = new DeleteFiles();
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileController> _logger;
        public FileController(IWebHostEnvironment webHostEnvironment, ILogger<FileController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        public async Task<string> FileUpload(IFormFile images)
        {
            try
            {
                if (images != null)
                {
                    string name = uploadFiles.UploadFile(images);
                    return name;
                }
                else return "null";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return "null";
            }

        }
      
        public async Task<IActionResult> FileDelete(string images)
        {
            try
            {
                if (images != null)
                {
                    deleteFiles.DeleteFile(_webHostEnvironment, images);
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
     
        public async Task<string> FileUpdate(IFormFile file, string? images)
        {
            try
            {
                if (file != null)
                {
                    if (!string.IsNullOrEmpty(images)) { deleteFiles.DeleteFile(_webHostEnvironment, images); }
                    string name = uploadFiles.UploadFile(file);
                    return name;
                }
                else return "null";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return "null";
            }

        }
    }
}
