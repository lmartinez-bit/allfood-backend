using AllfoodBackend.data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AllfoodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public ActionResult Get()
        {
            var ret = _productoRepository.GetMenu();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
