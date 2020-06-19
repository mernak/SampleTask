using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
