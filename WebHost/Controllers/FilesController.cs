using Application.Services.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    public class FilesController : BaseController
    {
        private readonly IFileService fileService;

        public FilesController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> PostFile([FromForm]FileCreateModel createFileModel)
        {
            FileModel file = await fileService.CreateFile(createFileModel);

            return Ok(file);
        }
    }
}
