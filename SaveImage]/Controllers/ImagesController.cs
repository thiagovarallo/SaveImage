using Microsoft.AspNetCore.Mvc;
using SaveImage_.DATA.DTOs;

namespace SaveImage_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm] FileUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                //User repository to upload image
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(FileUploadRequestDto request)
        {
            var allowedEctensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedEctensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsepported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file.");
            }
        }
    }
}
