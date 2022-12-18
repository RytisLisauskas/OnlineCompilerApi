using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public interface IUserService
    {
        public bool AddUser(string username, string password);
        public List<UserDTO> GetAllUsers();
        public UserDTO GetById(Guid id);
        public bool AddCompletedTask(Guid userId, AppTaskDTO task);

        public bool DeleteById(Guid id);
        public bool AddAnswerPoints(Guid user, int points);
    }
}
