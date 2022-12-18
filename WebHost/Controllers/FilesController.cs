using Application.Common.Model;
using Application.Services.Files;
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
            try
            {
                FileModel file = await fileService.CreateFile(createFileModel);

                return Ok(new ResponseModel(file));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }
    }
}
