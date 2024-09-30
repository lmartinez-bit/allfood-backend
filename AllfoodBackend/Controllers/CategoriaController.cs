using AllfoodBackend.data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AllfoodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            return Ok(await _categoriaRepository.GetCategoria());
        }
    }
}
