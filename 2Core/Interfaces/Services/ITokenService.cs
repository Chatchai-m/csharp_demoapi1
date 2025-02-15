using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Interfaces.Services
{
    public interface ITokenService
    {
        Task<bool> CreateTokenAsync(TokenServiceInput input);
        Task<TokenServiceResponse> GetTokenAsync(Int64 token_id);
    }

    public class TokenDTO
    {
        public Int64 id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? is_active { get; set; }
        public string token { get; set; }
        public int time_out { get; set; }
        public string? ip_address { get; set; }
        public string status { get; set; }
        public string app_name { get; set; }
    }

    public class TokenServiceInput
    {
        public Int64 id { get; set; }
        public bool is_active { get; set; }
        public string? token { get; set; }
        public int time_out { get; set; }
        public string? ip_address { get; set; }
        public string? status { get; set; }
        public string? app_name { get; set; }
        public Int64 user_id { get; set; }
    }

    public class TokenServiceResponse
    {
        public UserDTO user { get; set; }
        public TokenDTO token { get; set; }
    }
}
