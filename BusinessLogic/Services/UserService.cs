using Domain.Interfaces;
using Domain.Models;
using System.Text.RegularExpressions;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<User>> GetAll() => await _repositoryWrapper.User.FindAll();

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.Id == id);

            return user.First();
        }

        public async Task Create(User model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrWhiteSpace(model.Name)) throw new ArgumentException(nameof(model.Name));

            if (string.IsNullOrWhiteSpace(model.Surname)) throw new ArgumentException(nameof(model.Surname));

            Regex mailRegex = new Regex(@"\S*@\S*\.\S*");

            if (!mailRegex.IsMatch(model.Email)) throw new ArgumentException(nameof(model.Email));

            if (model.Password.Length < 5 || !model.Password.Any(x => char.IsDigit(x)) || !model.Password.Any(x => char.IsLetter(x)))
                throw new ArgumentException(nameof(model.Email));

            List<string> roles = new List<string>() { "Administrator", "Moderator", "User" };

            if (model.Balance < 0) throw new ArgumentException(nameof(model.Balance));

            if (!roles.Any(el => el == model.Role)) throw new ArgumentException(nameof(model.Role));



            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            await _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.Id == id);

            await _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _repositoryWrapper.User.GetByEmailAndPassword(email, password);
            return user;
        }
    }
}