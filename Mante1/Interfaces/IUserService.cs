
namespace Mante1.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetAllUsers();
        public Task<UserModel> GetByCod(string codUser);
        public Task AddUser(UserModel user);
        public Task UpdateUser(UserModel user);
        public Task DeleteUser(int id);
    }
}
