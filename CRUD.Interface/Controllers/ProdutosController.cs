using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Crosscutting.DTO;
using CRUD.Domain.Entities;
using CRUD.Service.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Interface.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoApplicationServices _appService;

        public ProdutosController(ProdutoApplicationServices appService)
        {
            _appService = appService;
        }

        public IActionResult Index()
        {
            try
            {
                var ListaProduto = _appService.GetListProduto();

                return View(ListaProduto);
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
                var Produto = _appService.GetProdutoById(id);

                return View(Produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

