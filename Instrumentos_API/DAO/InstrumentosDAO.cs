using Instrumentos_API.DataBase;
using Instrumentos_API.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instrumentos_API.DAO
{
    public class InstrumentosDAO : InterfaceInstrumentos
    {
        private MongoDBConnection mongoCon = new MongoDBConnection();
        private IMongoCollection<Instrumento> Collection;

        public InstrumentosDAO()
        {
            Collection = mongoCon.mongoDb.GetCollection<Instrumento>("instrumentos");
        }
        public async Task DeleteInstrumento(string id)
        {
            var filter = Builders<Instrumento>.Filter.Eq(i => i.id, new ObjectId(id));

            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Instrumento>> GetAllInstrumentos()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Instrumento> GetInstrumentoById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task InsertInstrumento(Instrumento instrumento)
        {
            await Collection.InsertOneAsync(instrumento);
        }

        public async Task UpdatePoduct(Instrumento instrumento)
        {
            var filter = Builders<Instrumento>.Filter.Eq(i => i.id, instrumento.id);
            await Collection.ReplaceOneAsync(filter,instrumento);
        }
    }
}
