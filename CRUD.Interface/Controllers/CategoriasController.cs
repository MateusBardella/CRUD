using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Crosscutting.DTO;
using CRUD.Domain.Entities;
using CRUD.Service.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUD.Interface.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaApplicationServices _appService;

        public CategoriasController(CategoriaApplicationServices appService)
        {
            _appService = appService;
        }

        public IActionResult Index()
        {
            try
            {
                var ListaCategoria = _appService.GetListCategoria();

                return View(ListaCategoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Update(int id)
        {
            try
            {
                var Categoria = _appService.GetCategoriaById(id);

                return View(Categoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
