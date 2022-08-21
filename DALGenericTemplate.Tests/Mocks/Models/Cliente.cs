using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Tests.Mocks.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
