using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Crosscutting.DTO;
using CRUD.Service.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUD.Interface.Controllers.API
{
    [ApiController]
    [Route("Api/Categorias")]
    public class ApiCategoriasController : Controller
    {
        private CategoriaApplicationServices _appService;

        public ApiCategoriasController(CategoriaApplicationServices appService)
        {
            _appService = appService;
        }

        [HttpGet("GetListCategoria")]
        public JsonResult GetListCategoria()
        {
            try
            {
                var _Json = JsonConvert.SerializeObject(_appService.GetListCategoria());

                return Json(_Json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Categoria = _appService.GetCategoriaById(id);

                return Ok(Categoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(CategoriaDTO data)
        {
            try
            {
                _appService.Insert(data);

                return Json(new { isValid = true });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, message = ex.Message });
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(CategoriaDTO categoriaDTO)
        {
            try
            {
                _appService.Update(categoriaDTO);

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
