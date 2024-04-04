using Application.InterfaceService;
using Application.Services;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class FileController : MainController
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpPost]
        public async Task<IActionResult> GetUrlFile(IFormFile file)
        {
            var result = await _fileService.UploadFile(file);
            return Ok(result);
        }
    }
}
