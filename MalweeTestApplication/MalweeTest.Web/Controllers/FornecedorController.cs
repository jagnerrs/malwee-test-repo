using MalweeTest.Data.DAO;
using MalweeTest.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MalweeTest.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private FornecedorDAO _fornecedorDAO = new FornecedorDAO();

        [HttpGet]
        public JsonResult CarregarFornecedores()
        {
            List<Fornecedor> list = _fornecedorDAO.GetAll();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}