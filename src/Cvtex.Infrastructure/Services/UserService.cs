using System;
using System.Threading.Tasks;
using Cvtex.Core.Domain;
using Cvtex.Infrastructure.Repositories;
using Cvtex.Infrastructure.DTO;
using AutoMapper;
using Cvtex.Infrastructure.Extensions;
using Cvtex.Infrastructure.Exceptions;
using NLog;

namespace Cvtex.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IEncrypter encrypter,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetOrFailAsync(email);
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task LoginAsync(string email, string password)
        {
            Logger.Debug("We are inside LogingAsync");
            var user = await _userRepository.GetOrFailAsync(email);
            if (user == null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials, "Invalid credentials");
            }
            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }

            throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials, "Invalid credentials");
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password)
        {
            try
            {
                var user = await _userRepository.GetAsync(email);
                if(user != null)
                {
                    throw new ServiceException(Exceptions.ErrorCodes.EmailInUse, $"User with email '{email}' already exists.");
                }

                var salt = _encrypter.GetSalt(password); //Guid.NewGuid().ToString("N"); // Formatowanie do ciągu znaków bez myślników
                var hash = _encrypter.GetHash(password, salt);
                user = new User(userId, email, username, password, salt);
                await _userRepository.AddAsync(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}