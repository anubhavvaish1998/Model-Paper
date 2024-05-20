using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Model_Paper.Controllers
{
    public class FileController : Controller
    {
        [HttpPost("File/Upload")]
        public async Task<IActionResult> Upload(IFormFile fileToUpload)
        {
            if (fileToUpload == null || fileToUpload.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            var filePath = Path.Combine(uploadsFolder, fileToUpload.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileToUpload.CopyToAsync(stream);
            }

            return Ok("File uploaded successfully!");
        }
    }
}
