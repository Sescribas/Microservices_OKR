using MongoDB.Bson;
using MongoDB.Driver;
using OKR.Common.Domain;
using OKR.Common.Persistence.Database.SellDbContext;
using OKR.Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Repositories
{
    public class SellCollection : ISellCollection
    {
        private MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Sell> _collection;

        public SellCollection()
        {
            _collection = _repository.db.GetCollection<Sell>("Sells");
        }

        public async Task DeleteSell(string id)
        {
            var filter = Builders<Sell>.Filter.Eq(s => s.Id, new ObjectId(id));
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<List<Sell>> GetAllSell()
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Sell> GetSellById(string id)
        {
            return await _collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstOrDefaultAsync();
        }

        public async Task InsertSell(Sell sell)
        {
            await _collection.InsertOneAsync(sell);
        }

        public async Task UpdateSell(Sell sell)
        {
            var filter = Builders<Sell>.Filter.Eq(s => s.Id, sell.Id);
            await _collection.ReplaceOneAsync(filter,sell);
        }
    }
}
