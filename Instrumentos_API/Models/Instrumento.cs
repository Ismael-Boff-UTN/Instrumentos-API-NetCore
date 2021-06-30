using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instrumentos_API.Models
{
    public class Instrumento
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string instrumento { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string imagen { get; set; }
        public string precio { get; set; }
        public string costoEnvio { get; set; }
        public string cantidadVendida { get; set; }
        public string descripcion { get; set; }
    }
}
