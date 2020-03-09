using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDockerLnx.Models
{
    public class RespPerson
    {
        public FilaPerson Resultado { get; set; }
    }

    public class FilaPerson
    {
        public List<PersonaResp> fila { get; set; }
    }
    public class RespPersonUnique
    {
        public FilaPersonUnique Resultado { get; set; }
    }

    public class FilaPersonUnique
    {
        public PersonaResp fila { get; set; }
    }
    public class PersonaResp
    {
        public int ICVEPERSONA { get; set; }
        public string CNOMBRE { get; set; }
        public string CAPPATERNO { get; set; }
        public string CAPMATERNO { get; set; }
        public int LACTIVO { get; set; }
        public int ESTATUS { get; set; }
    }
}
