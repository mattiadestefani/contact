using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneContatti;

namespace FileHelper
{
    public interface ITraslate
    {
        List<Persona> GetPersone(List<string> rows);
        List<string> PutPersona(List<Persona> persone);
    }
}
