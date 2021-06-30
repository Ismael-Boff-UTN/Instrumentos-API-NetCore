using Instrumentos_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instrumentos_API.DAO
{
    interface InterfaceInstrumentos
    {
        Task InsertInstrumento(Instrumento instumento);
        Task UpdatePoduct(Instrumento instrumento);
        Task DeleteInstrumento(string id);

        Task<List<Instrumento>> GetAllInstrumentos();
        Task<Instrumento> GetInstrumentoById(string id);

        
    }
}
