using _2Core.Interfaces.Infra.Database;
using _2Core.Interfaces.Services;
using _1Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitWork _unitWork;
        private readonly IDateTimeService _dateTimeService;

        public TokenService(IUnitWork unitWork, IDateTimeService dateTimeService)
        {
            _unitWork = unitWork;
            _dateTimeService = dateTimeService;
        }

        public async Task<bool> CreateTokenAsync(TokenServiceInput input)
        {
            DateTime dateTime = _dateTimeService.Now;
            Token token_instance = _unitWork.TokenRepository.GetQueryable().Where(x => x.id == input.id).FirstOrDefault();
            if (token_instance == null)
            {
                token_instance = new Token();
                token_instance.created_at = dateTime;
            }
            token_instance.token = input.token;
            token_instance.time_out = input.time_out;
            token_instance.ip_address = input.ip_address;
            token_instance.status = input.status;
            token_instance.app_name = "TEST";
            token_instance.user_id = input.user_id;
            token_instance.updated_at = dateTime;
            token_instance.is_active = true;
            await _unitWork.TokenRepository.InsertOrUpdateAsynce(token_instance);
            return true;
        }

        public async Task<TokenServiceResponse> GetTokenAsync(Int64 token_id)
        {
            //TokenServiceResponse rs = new TokenServiceResponse();
            var query = (
                from q_token in _unitWork.TokenRepository.GetQueryable()
                join q_user in _unitWork.UserRepository.GetQueryable() on q_token.user_id equals q_user.id into temp_q_user
                from q_user in temp_q_user.DefaultIfEmpty()
                where q_token.id == token_id
                select new
                {
                    q_user,
                    q_token,
                }
            ).FirstOrDefault();


            TokenServiceResponse rs = new TokenServiceResponse();

            if (query != null)
            {
                UserDTO userDTO = new UserDTO()
                {
                    id = query.q_user.id,
                    created_at = query.q_user.created_at,
                    updated_at = query.q_user.updated_at,
                    is_active = query.q_user.is_active,
                    email = query.q_user.email,
                    firstname = query.q_user.firstname,
                    lastname = query.q_user.lastname,
                    roles = query.q_user.roles,
                    info = query.q_user.info,
                    //fullname = this.GetType().FullName,
                };

                userDTO.fullname = userDTO.getFullname();

                TokenDTO tokenDTO = new TokenDTO()
                {
                    id = query.q_token.id,
                    created_at = query.q_token.created_at,
                    updated_at = query.q_token.updated_at,
                    is_active = query.q_token.is_active,
                    token = query.q_token.token,
                    time_out = query.q_token.time_out,
                    ip_address = query.q_token.ip_address,
                    status = query.q_token.status,
                    app_name = query.q_token.app_name,
                };

                rs.user = userDTO;
                rs.token = tokenDTO;
            }


            return rs;
        }
    }
}
