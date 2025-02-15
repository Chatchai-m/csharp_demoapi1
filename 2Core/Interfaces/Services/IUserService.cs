using _1Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserServiceInput input);

    }
    public class UserDTO
    {
        public Int64 id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? is_active { get; set; }
        public string email { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string roles { get; set; }
        public string? info { get; set; }
        public string? fullname { get; set; }
        public string getFullname()
        {
            return $"{this.firstname}  {this.lastname}";
        }
    }

    public class UserServiceInput
    {
        public Int64 id { get; set; }
        public bool is_active { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? roles { get; set; }
        public string? info { get; set; }
    }

    public class UserServiceResponse
    {
        public User user { get; set; }
        public Collection<Token> tokens { get; set; }
        public dynamic data { get; set; }
    }

}
