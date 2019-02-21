using MalweeTest.Data.DAO;
using MalweeTest.Entities;
using MalweeTest.Entities.ViewModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MalweeTest.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private FornecedorDAO _fornecedorDAO = new FornecedorDAO();
        private ServicoPrestadoDAO _servicoPrestadoDAO = new ServicoPrestadoDAO();

        [HttpGet]
        public JsonResult CarregarFornecedores()
        {
            List<Fornecedor> list = _fornecedorDAO.GetAll();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FornecedoresInativos()
        {
            List<FornecedorInativoViewModel> fornecedoresInativos = new List<FornecedorInativoViewModel>();

            var fornecedores = _fornecedorDAO.GetAll();
            var servicosPrestados = _servicoPrestadoDAO.GetAll();

            int mesAtual = DateTime.Today.Month;

            for (int i = 1; i < (mesAtual + 1); i++)
            {
                foreach (Fornecedor fornecedor in fornecedores)
                {
                    var obj = servicosPrestados.FirstOrDefault(o => o.FornecedorId == fornecedor.Id &&
                                                                    o.Data.Month == i);

                    if(obj == null)
                    {
                        fornecedoresInativos.Add(new FornecedorInativoViewModel() { Mes = i, Fornecedor = fornecedor });
                    }
                }
            }

            var _result = fornecedoresInativos.OrderBy(o => o.Mes)
                                                .ThenBy(o => o.Fornecedor.Nome)
                                                .GroupBy(o => o.Mes)
                                                .Select(o => o.ToList())
                                                .ToList();

            return PartialView(_result);
        }
    }
}