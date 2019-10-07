using ChatInc.Data;
using ChatInc.Domain;
using ChatInc.Services.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ChatInc.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ChatIncDbContext _db;

        public UserService(IOptions<AppSettings> appSettings, ChatIncDbContext db)
        {
            _appSettings = appSettings.Value;
            _db = db;
        }


        public User Authenticate(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);


            _db.Users.Update(user);
            _db.SaveChanges();

            user.Password = null;

            return user;

        }

        //Will not be encrypting password as this is just a training app
        public User CreateUser(string username, string password)
        {
            if (_db.Users.FirstOrDefault(x => x.Username == username) != null)
            {
                return null;
            }


            User user = new User
            {
                Username = username,
                Password = password
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }

        
        public IEnumerable<User> GetAll()
        {
            var users = _db.Users.ToList().Select(x =>
            {
                x.Password = null;
                return x;
            });

            return users;
        }
    }
}
