using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.API.CustomAttributes;
using Product.API.DTO;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }
         
        [HttpGet]
        [IsAuthorizedFilter]
        public IActionResult GetProducts()
        {
            _logger.LogInformation("ProductController getProduct route");
            // return StatusCode(StatusCodes.Status418ImATeapot, "get the fuck up message");
            return StatusCode(StatusCodes.Status418ImATeapot, "get the fuck wafewafaw fwarwf rfhewfsfsdaw efup message");
        }
        
        [HttpPost]
        [IsAuthorizedFilter]
        public IActionResult CeatePost([FromBody] CreateProductBody product)
        {
            throw new Exception("just testing exception");
            return StatusCode(StatusCodes.Status418ImATeapot, "creating product...");
        }
    }
};