using Entities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserService
    {
        private readonly UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
        }

        public void CreateUserIfNotExists(UserModel user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                return; // or throw an exception if email is required

            var existingUser = _repo.GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                _repo.AddUser(user);
            }
        }
    }
}
