﻿namespace SaveImage_.DATA.DTOs
{
    public class FileUploadRequestDto
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
    }
}
