using CRUD.Crosscutting.DTO;
using CRUD.Service.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD.Interface.Controllers.API
{
    [ApiController]
    [Route("Api/Produtos")]
    public class ApiProdutosController : Controller
    {
        private ProdutoApplicationServices _appService;

        public ApiProdutosController(ProdutoApplicationServices appService)
        {
            _appService = appService;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Produto = _appService.GetProdutoById(id);

                return Ok(Produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(ProdutoDTO produtoDTO)
        {
            try
            {
                _appService.Insert(produtoDTO);

                return Json(new { isValid = true });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, message = ex.Message });
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(ProdutoDTO produtoDTO)
        {
            try
            {
                _appService.Update(produtoDTO);

                return Json(new { isValid = true });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, message = ex.Message });
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _appService.Delete(id);

                return Json(new { isValid = true });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, message = ex.Message });
            }
        }
    }
}
