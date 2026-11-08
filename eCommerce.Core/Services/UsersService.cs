
using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository usersRepository,
                            IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginrequest)
        {
             var user = await _usersRepository.GetUserByEmailAndPassword(loginrequest.Email,loginrequest.Password);
            if(user == null)
            {
                return null;
            }
            return _mapper.Map<AuthenticationResponse>(user) with {Success = true,Token = "token"};

        }


        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
           
            var user = _mapper.Map<ApplicationUser>(registerRequest);
            var registeredUser = await _usersRepository.AddUser(user);
            if(registeredUser == null)
            {
              return null;
            }
            return _mapper.Map<AuthenticationResponse>(user) with {Success = true,Token = "token"};;
        }
    }
}