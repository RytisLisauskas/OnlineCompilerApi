using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Data.Repositories
{
    public interface IUserRepo
    {
        public bool CreateUser(string username, string password);
        public List<UserDTO> GetAllUsers();
        public UserDTO GetById(Guid id);
        public UserDTO UpdateUser(UserDTO userToUpdate);
        public bool DeleteUser(Guid id);
        public bool AddPointsToUser(Guid id, int points);

    }
}
