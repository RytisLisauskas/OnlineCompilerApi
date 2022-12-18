using OnlineCompiler.Data.Repositories;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo repo)
        { 
            this._userRepo = repo;
        }

        public bool AddCompletedTask(Guid userId, AppTaskDTO task)
        {
            var user = GetById(userId);
            user.CompletedTasks?.Add(new CompletedTaskDTO(task));
            UpdateUser(user);
            return true;
        }

        public bool AddUser(string username, string password)
        {
            return _userRepo.CreateUser(username, password);
        }

        public bool DeleteById(Guid id)
        {
           return _userRepo.DeleteUser(id);
        }

        public List<UserDTO> GetAllUsers()
        {
           return _userRepo.GetAllUsers();
        }

        public UserDTO GetById(Guid id)
        {
           return _userRepo.GetById(id);
        }

        public UserDTO UpdateUser(UserDTO userToUpdate)
        {
            return _userRepo.UpdateUser(userToUpdate);
        }

        public bool AddAnswerPoints(Guid user, int points)
        { 
            return _userRepo.AddPointsToUser(user, points);
        }
    }
}
