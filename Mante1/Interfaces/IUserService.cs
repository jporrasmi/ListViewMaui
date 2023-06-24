
namespace Mante1.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetAllUsers();
        public Task<UserModel> GetByCod(string codUser);
        public Task<bool> AddUser(UserModel user);
        public Task<bool> UpdateUser(UserModel user);
        public Task<bool> DeleteUser(string codUser);
    }
}
