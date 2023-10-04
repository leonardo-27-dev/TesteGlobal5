using CRUD_GLOBAL5.Models;
using CRUD_GLOBAL5.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_GLOBAL5.Controllers
{
    public class ConsultaController : Controller
    {

        private readonly IMarcaRepositorio _marcaRepositorio;

        public ConsultaController(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }


        public IActionResult Index()
        {
            List<ConsultaModel> marcas = _marcaRepositorio.BuscarTodos();
            return View(marcas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ConsultaModel marca = _marcaRepositorio.ListarPorId(id);
            return View(marca);
        }

        [HttpPost]
        public IActionResult Criar(ConsultaModel teste)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool marcaJaExiste = _marcaRepositorio.BuscarTodos().Any(x => x.Marca == teste.Marca);

                    if (!marcaJaExiste)
                    {
                        _marcaRepositorio.Adicionar(teste);
                        TempData["MensagemSucesso"] = "Marca registrada com Sucesso";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Marca já registrada!";
                        return RedirectToAction("Index");
                    }
                }

                return View(teste);
            }
            catch (DbUpdateException ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um problema ao cadastrar, verifique os campos e tente novamente! {ex.Message}";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro inesperado: {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(ConsultaModel teste)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _marcaRepositorio.Atualizar(teste);
                    TempData["MensagemSucesso"] = "Marca alterada com Sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", teste);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Ocorreu um problema ao editar a marca, verifique os campos e tente novamente! {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

