namespace CourseProject.Helper
{
    public class AddImageFile
    {
        private readonly IWebHostEnvironment _environment;

        public AddImageFile(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // subDirectory : wwwroot altında nereye kaydedileceğini belirtir

        public async Task<string> UploadFileAsync(IFormFile file, string subDirectory)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadsFolder = Path.Combine(_environment.WebRootPath, subDirectory);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // URL path for the client
            string relativePath = Path.Combine(subDirectory, file.FileName).Replace("\\", "/");
            return "/" + relativePath;
        }

    }
}
