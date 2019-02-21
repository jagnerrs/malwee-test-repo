using MalweeTest.Data.DAO;
using MalweeTest.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MalweeTest.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteDAO _clienteDAO = new ClienteDAO();

        [HttpGet]
        public JsonResult CarregarClientes()
        {
            List<Cliente> list = _clienteDAO.GetAll();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}