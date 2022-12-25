using EntityModel;
using JsonFileData;
using Service;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    
    public class CustomerService
    {
        private string _newFilePath;
        private IDataStore _service;
        private IDocumentCollection<dynamic> _collection;

       
        public CustomerService()
        {
            _newFilePath = UTHelpers.Up();
            _service = new DataStore(_newFilePath);
            _collection = _service.GetCollection("Customer");
        }

       
       //  public void GlobalCleanup() => UTHelpers.Down(_newFilePath);       

        public dynamic AsQueryable_Single(int id)
        {
            var item = _collection.AsQueryable().Single(e => e.id == id);
            return item;
        }

       
        public async Task InsertOneAsync(Customer customer)
        {
            await _collection.InsertOneAsync(new { name = customer.Name });
        }

       
        public void InsertOne(Customer customer)
        {
            _collection.InsertOne(new { name = customer.Name });
        }

      
        public async Task InsertManyAsync()
        {
            var items = Enumerable.Range(0, 100).Select(e => new { id = e, name = $"Teddy_{e}" });
            await _collection.InsertManyAsync(items);
        }

       
        public void InsertMany()
        {
            var items = Enumerable.Range(0, 100).Select(e => new { id = e, name = $"Teddy_{e}" });
            _collection.InsertMany(items);
        }

       
        public async Task DeleteOneAsync_With_Id(int id)
        {
            await _collection.DeleteOneAsync(id);
        }

       
        public async Task DeleteOneAsync_With_Predicate()
        {
            await _collection.DeleteOneAsync(e => e.id == 1);
        }

       
        public void DeleteMany()
        {
            _collection.DeleteMany(e => true);
        }

       
        public async Task DeleteManyAsync()
        {
            await _collection.DeleteManyAsync(e => true);
        }

        public void ReplaceOne_With_Predicate()
        {
            _collection.ReplaceOne(e => e.id == 1, new { id = 1, name = "Teddy" });
        }

       
        public void ReplaceOne_With_Id()
        {
            _collection.ReplaceOne(1, new { id = 1, name = "Teddy" });
        }

       
        public async Task ReplaceOneAsync_With_Predicate()
        {
            await _collection.ReplaceOneAsync(e => e.id == 1, new { id = 1, name = "Teddy" });
        }

        
        public async Task ReplaceOneAsync_With_Id()
        {
            await _collection.ReplaceOneAsync(1, new { id = 1, name = "Teddy" });
        }

       
        public void ReplaceMany(Customer customer)
        {
            _collection.ReplaceMany(e => true, new { id = customer.Id, name = customer.Name });
        }

       
        public async Task ReplaceManyAsync()
        {
            await _collection.ReplaceManyAsync(e => true, new { id = 1, name = "Teddy" });
        }

       
        public void UpdateOne(Customer customer)
        {
            _collection.UpdateOne(e => e.id == customer.Id, new { name = customer.Name });
        }

       
        public async Task UpdateOneAsync()
        {
            await _collection.UpdateOneAsync(e => e.id == 1, new { name = "Teddy" });
        }

       
        public void UpdateMany()
        {
            _collection.UpdateMany(e => true, new { name = "Teddy" });
        }

       
        public async Task UpdateManyAsync()
        {
            await _collection.UpdateManyAsync(e => true, new { name = "Teddy" });
        }

       
        public void Find_With_Predicate()
        {
            _collection.Find(e => e.id == 1);
        }

       
        public dynamic Find_With_Text(String cusomerName)
        {
         var item =  _collection.Find(cusomerName);
            return item;
        }

       
        public void GetNextIdValue()
        {
            _collection.GetNextIdValue();
        }
    }
}