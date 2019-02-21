using MalweeTest.Data;
using MalweeTest.Data.DAO;
using MalweeTest.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MalweeTest.Web.Controllers
{
    public class ServicoPrestadoController : Controller
    {
        private ServicoPrestadoDAO _servicoPrestadoDAO = new ServicoPrestadoDAO();
        private ClienteDAO _clienteDAO = new ClienteDAO();

        public ServicoPrestadoController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public ServicoPrestadoController(UserManager<ApplicationUser> userManager)
        { 
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public ActionResult Create()
        {
            ServicoPrestado servicoPrestado = new ServicoPrestado();
            servicoPrestado.FornecedorId = UserManager.FindById(User.Identity.GetUserId()).FornecedorId;
            return View(servicoPrestado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoPrestado servicoPrestado)
        {
            if (ModelState.IsValid)
            {
                _servicoPrestadoDAO.Save(servicoPrestado);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult FilterReport()
        {
            var clientes = _clienteDAO.GetAll();

            FilterServicoPrestadoViewModel filter = new FilterServicoPrestadoViewModel();
            filter.DropDownClientes = new SelectList(clientes, "Id", "Nome");
            filter.DropDownTipoServico = new SelectList(TipoServico.List, "Value", "Text");

            return PartialView(filter);
        }

        /// <summary>
        /// Relatório de serviços prestados
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult Report(FilterServicoPrestadoViewModel filter)
        {
            var servicosPrestados = _servicoPrestadoDAO.GetReport(filter);

            return View(servicosPrestados);
        }

        /// <summary>
        /// Os 3 clientes que mais gastaram em serviços por mês no ano atual
        /// </summary>
        /// <returns></returns>
        public ActionResult TopClientesPorMes()
        {
            var servicosPrestados = _servicoPrestadoDAO.GetTopClientesPorMes();

            return PartialView(servicosPrestados);
        }
    }
}