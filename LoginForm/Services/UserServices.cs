using LoginForm.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using LoginForm.Models;

namespace LoginForm.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> UserCollection;

        public UserServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.Connection);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            UserCollection = mongoDb.GetCollection<User>(databaseSettings.Value.CollectionName);
        }

        // get all students
        public async Task<List<User>> GetAsync() => await UserCollection.Find(_ => true).ToListAsync();


        // get student by id
        public async Task<User> GetAsync(string id) =>
            await UserCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // add new student 
        public async Task CreateAsync(User newStudent) =>
            await UserCollection.InsertOneAsync(newStudent);

        // update student

        public async Task UpdateAsync(string id, User updateStudent) =>
            await UserCollection.ReplaceOneAsync(x => x.Id == id, updateStudent);

        // delete student
        public async Task RemoveAsync(string id) =>
            await UserCollection.DeleteOneAsync(x => x.Id == id);
    }
}