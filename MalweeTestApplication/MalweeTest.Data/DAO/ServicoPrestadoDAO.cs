using MalweeTest.Entities;
using MalweeTest.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MalweeTest.Data.DAO
{
    public class ServicoPrestadoDAO : AbstractDAO<ServicoPrestado, int>
    {
        public override bool Delete(ServicoPrestado entity)
        {
            int result = 0;

            using (var context = new ApplicationDbContext())
            {
                context.ServicosPrestados.Attach(entity);
                context.Entry(entity).State = EntityState.Deleted;
                result = context.SaveChanges();
            }

            return result > 0;
        }

        public override bool DeleteById(int id)
        {
            bool result = false;

            using (var context = new ApplicationDbContext())
            {
                ServicoPrestado servicoPrestado = context.ServicosPrestados
                                .Where(o => o.Id == id)
                                .FirstOrDefault();

                result = Delete(servicoPrestado);
            }

            return result;
        }

        public override List<ServicoPrestado> GetAll()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    return context.ServicosPrestados
                                  .Include(o => o.Cliente)
                                  .Include(o => o.Fornecedor)
                                  .ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override ServicoPrestado GetById(int id)
        {
            ServicoPrestado result = null;

            using (var context = new ApplicationDbContext())
            {
                result = context.ServicosPrestados
                                .Where(o => o.Id == id)
                                .FirstOrDefault();

                return result;
            }
        }

        public  List<ServicoPrestado> GetReport(FilterServicoPrestadoViewModel filter)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var _result = context.ServicosPrestados.Include(o => o.Cliente)
                                                           .Include(o => o.Fornecedor)
                                                           .Where(o => o.ClienteId == (filter.Cliente > 0 ? filter.Cliente : o.ClienteId) &&
                                                                       o.Cliente.Estado == (!string.IsNullOrEmpty(filter.Estado) ? filter.Estado : o.Cliente.Estado) &&
                                                                       o.Cliente.Cidade == (!string.IsNullOrEmpty(filter.Cidade) ? filter.Cidade : o.Cliente.Cidade) &&
                                                                       o.Cliente.Bairro == (!string.IsNullOrEmpty(filter.Bairro) ? filter.Bairro : o.Cliente.Bairro) &&
                                                                       o.Tipo == (!string.IsNullOrEmpty(filter.TipoServico) ? filter.TipoServico : o.Tipo))
                                                           .OrderBy(o => o.Id)
                                                           .ToList();

                    if (filter.DataInicio != DateTime.MinValue)
                    {
                        _result = _result.Where(o => o.Data >= filter.DataInicio.Date).ToList();
                    }

                    if (filter.DataFim != DateTime.MinValue)
                    {
                        _result = _result.Where(o => o.Data <= filter.DataFim.Date).ToList();
                    }

                    if (filter.ValorMinimo > 0)
                    {
                        _result = _result.Where(o => o.Valor >= filter.ValorMinimo).ToList();
                    }

                    if (filter.ValorMaximo > 0)
                    {
                        _result = _result.Where(o => o.Valor <= filter.ValorMaximo).ToList();
                    }

                    return _result;
                           
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<List<TopClienteViewModel>> GetTopClientesPorMes()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // recupera todos os serviços prestados
                    var _list = GetAll();

                    // filtra somente os registros do ano atual
                    _list = _list.Where(o => o.Data.Year == DateTime.Today.Year).ToList();


                    var query = from e in _list
                                group e by new { e.Cliente, e.Data.Month } into eg
                                select new { eg.Key.Cliente, eg.Key.Month, Valor = eg.Sum(rl => rl.Valor) };


                    var _clientes = new List<TopClienteViewModel>();

                    foreach (var item in query.ToList())
                    {
                        TopClienteViewModel topCliente = new TopClienteViewModel();
                        topCliente.Cliente = item.Cliente;
                        topCliente.Mes = item.Month;
                        topCliente.Valor = (decimal)item.Valor;

                        _clientes.Add(topCliente);
                    }

                    var _result = _clientes.GroupBy(o => o.Mes)
                                           .Select(o => o.ToList())
                                           .ToList();


                    return _result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<List<CustoMedioViewModel>> GetCustoMedioPorFornecedor()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var _servicos = GetAll();

                    var query = from e in _servicos
                                group e by new { e.Fornecedor, e.Tipo } into eg
                                select new { eg.Key.Fornecedor, eg.Key.Tipo, CustoMedio = eg.Average(rl => rl.Valor) };

                    var _list = new List<CustoMedioViewModel>();

                    foreach (var item in query.ToList())
                    {
                        CustoMedioViewModel custoMedio = new CustoMedioViewModel();
                        custoMedio.Fornecedor = item.Fornecedor;
                        custoMedio.TipoServico = TipoServico.Description(item.Tipo);
                        custoMedio.Valor = (decimal)item.CustoMedio;

                        _list.Add(custoMedio);
                    }

                    var _result = _list.GroupBy(o => o.Fornecedor)
                                       .Select(o => o.ToList())
                                       .ToList();

                    return _result;

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override bool Save(ServicoPrestado entity)
        {
            int result = 0;

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.ServicosPrestados.Add(entity);
                    result = context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result > 0;
        }

        public override void Update(ServicoPrestado entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.ServicosPrestados.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
