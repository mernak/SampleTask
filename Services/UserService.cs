using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Helpers;
using SampleTaskServerSide.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly SampleWebProjectDbContext _context;
        private readonly IMapper _mapper;
        public UserService(IOptions<AppSettings> appSettings, SampleWebProjectDbContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }
     
        

        public User Authenticate(string username, string password)
        {
            List<UserEntity> _users = _context.Users.ToList();
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            
            return _mapper.Map<User>(user).WithoutPassword();
        }
        public IEnumerable<User> GetAll()
        {
            List<UserEntity> _users = _context.Users.ToList();
            
            return _mapper.Map<List<User>>(_users).WithoutPasswords();
        }

        public User GetById(int id)
        {
            List<UserEntity> _users = _context.Users.ToList();
            var user = _users.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<User>(user).WithoutPassword();
        }

        public  User PostUserAsync(UserEntity user)
        {
            var bytePassword = Encoding.ASCII.GetBytes(user.Password); 
            _context.Users.Add(user);
           // string passwordStr = Encoding.ASCII.GetString(user.Password);
            if (user.Role == Role.Trainer)
            {
                var trainer = new TrainerEntity
                {
                    Username = user.Username,
                    Password = user.Password
                };
                _context.Trainers.Add(trainer);
            }
            else if(user.Role == Role.Member)
            {
                var member = new MemberEntity
                {
                    Username = user.Username,
                    Password = user.Password,
                    PackageId = null,
                    TrainerId = null
            };
                _context.Members.Add(member);
            }
             _context.SaveChanges();
  
            return _mapper.Map<User>(user);
        }
    }
}
