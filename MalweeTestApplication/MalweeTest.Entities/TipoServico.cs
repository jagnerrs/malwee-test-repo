using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MalweeTest.Entities
{
    public static class TipoServico
    {
        private const string CONSERTO_ELETRONICO = "Conserto eletrônico";
        private const string SERVICOS_GERAIS = "Serviços gerais";
        private const string MANUTENCAO_HIDRAULICA = "Manutenção hidráulica";
        private const string INSTALACAO_ELETRICA = "Instalação elétrica";
        private const string JARDINAGEM = "Jardinagem";

        public static IEnumerable<SelectListItem> List
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = CONSERTO_ELETRONICO, Value = "CE" },
                    new SelectListItem { Text = SERVICOS_GERAIS, Value = "SG" },
                    new SelectListItem { Text = MANUTENCAO_HIDRAULICA, Value = "MH" },
                    new SelectListItem { Text = INSTALACAO_ELETRICA, Value = "IE" },
                    new SelectListItem { Text = JARDINAGEM, Value = "JA" },
                };
            }
        }

        public static string Description(string sigla)
        {
            string result = string.Empty;

            switch (sigla)
            {
                case "CE":
                    result = CONSERTO_ELETRONICO;
                    break;
                case "SG":
                    result = SERVICOS_GERAIS;
                    break;
                case "MH":
                    result = MANUTENCAO_HIDRAULICA;
                    break;
                case "IE":
                    result = INSTALACAO_ELETRICA;
                    break;
                case "JA":
                    result = JARDINAGEM;
                    break;
                default:
                    break;
            }


            return result;
        }
    }
}
