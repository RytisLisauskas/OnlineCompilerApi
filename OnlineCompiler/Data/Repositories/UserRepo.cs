using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCompiler.Data.DBModels;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly IMapper _mapper;
        OnlineCompilerDbContext Context { get; set; }

        public UserRepo(IMapper mapper)
        {
            this._mapper = mapper;
            Context = new OnlineCompilerDbContext();
        }

        public bool CreateUser(string username, string password)
        {
            User user = new User(username, password, new List<CompletedTask>());
            if (Context.Users.Where(x => x.Username == username).ToList().Count() > 0)
            {
                return false;
            }
            Context.Users.Add(user);
            Context.SaveChanges();
            return true;

        }

        public List<UserDTO> GetAllUsers()
        {
            var allUsers = Context.Users.Include(user => user.CompletedTasks).ToList();
            var mappedUsers = _mapper.Map<List<User>, List<UserDTO>>(allUsers);
            return mappedUsers;
        }

        public UserDTO GetById(Guid id)
        {
            return _mapper.Map<User, UserDTO>(Context.Users.Include(user => user.CompletedTasks).First(x => x.ResourceId == id));
        }

        public UserDTO UpdateUser(UserDTO userToUpdate)
        {
            if (Context.Users.FirstOrDefault(x => x.ResourceId == userToUpdate.ResourceId) != null)
            { 
                var user = Context.Users.First(x => x.ResourceId == userToUpdate.ResourceId);
                user.Username = userToUpdate.Username!;
                user.Password = userToUpdate.Password!;
                user.CompletedTasks = _mapper.Map<List<CompletedTaskDTO>,List<CompletedTask>>(userToUpdate.CompletedTasks!);
                user.PointsFromQuestions = userToUpdate.PointsFromQuestions;
                Context.SaveChanges();
                return _mapper.Map<User, UserDTO>(user);
            }
            return userToUpdate;
        }

        public bool DeleteUser(Guid id)
        {
            var user = Context.Users.FirstOrDefault(user => user.ResourceId == id);
            if (user != null)
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddPointsToUser(Guid id, int points)
        {
            if (points < 0)
            {
                return false;
            }
            var user = Context.Users.FirstOrDefault(user => user.ResourceId == id);
            if (user == null)
            {
                return false;
            }
            user.PointsFromQuestions += points;
            Context.SaveChanges();
            return true;

        }
    }
}
