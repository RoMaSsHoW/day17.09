using HomeWork.Application.Models.DTOs;
using HomeWork.Application.Models.Responses;
using HomeWork.Application.Services;
using HomeWork.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber)
        {
            var authors = await _authorService.GetAllAsync(pageNumber);
            return Ok(new Response<IEnumerable<Author>>(authors));
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] AuthorCreateDTO dto)
        {
            var created = await _authorService.CreateAsync(dto);
            return Ok(created);
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] AuthorEditPhotoDTO dto)
        {
            var created = await _authorService.EditAsync(dto);
            return Ok(created);
        }
    }
}
