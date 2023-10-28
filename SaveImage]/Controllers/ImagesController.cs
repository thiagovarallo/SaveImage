using Microsoft.AspNetCore.Mvc;
using SaveImage_.DATA.DTOs;
using SaveImage_.Models;
using SaveImage_.Repository;

namespace SaveImage_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm] FileUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                //covert DTO to Domain model
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };

                //User repository to upload image
                await imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);

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
