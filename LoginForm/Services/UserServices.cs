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

        // get all users
        public async Task<List<User>> GetAsync() => await UserCollection.Find(_ => true).ToListAsync();


        // get user by id
        public async Task<User> GetAsync(string id) =>
            await UserCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // add new user 
        public async Task CreateAsync(User newUser) =>
            await UserCollection.InsertOneAsync(newUser);
    }
}

