namespace EsportsProfileWebApi.Web.Repository;

using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.User;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Security.Claims;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserEntity> _userCollection;
    private readonly MongoClient _mongoClient;

    public UserRepository(IConfiguration configuration)
    {
        _mongoClient = new MongoClient(configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException());

        var mongoDatabase = _mongoClient.GetDatabase("EsportsCompare");

        _userCollection = mongoDatabase.GetCollection<UserEntity>("Users");
    }

    public async Task<bool> UserExists(string userName)
    {
        if (await _userCollection.Find(user => user.UserName == userName).FirstOrDefaultAsync() == null)
            return false;
        return true;
    }

    public async Task<UserEntity> RegisterUser(UserRegisterRequestModel request)
    {
        var userId = Guid.NewGuid().ToString();
        var claims = new List<Claim>()
        {
            new Claim("UserId", userId),
            new Claim("Role", "User")
        };
        var user = new UserEntity()
        {
            UserId = userId,
            UserName = request.Username,
            Email = request.Email,
            Password = Helpers.PasswordHashing.HashPassword(request.Password),
            Claims = claims
        };

        await _userCollection.InsertOneAsync(user);
        return user;
    }

    public async Task<UserEntity> LoginUser(UserLoginRequestModel request)
    {
        return await _userCollection.Find(user => user.Password == Helpers.PasswordHashing.HashPassword(request.Password)).FirstOrDefaultAsync();
    }
}