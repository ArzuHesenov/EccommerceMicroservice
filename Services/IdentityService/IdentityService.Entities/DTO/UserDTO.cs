using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Entities.DTO
{
    public class UserDTO
    {
        public record LoginDTO(string Email,string Password);
        public record RegisterDTO(string Name, string Surname, string Email,string UserName, string Password,DateTime BirthDay);
        public record UserByEmailDTO(string Name, string Surname, string Email,string UserName, DateTime BirthDay);
    }
}
