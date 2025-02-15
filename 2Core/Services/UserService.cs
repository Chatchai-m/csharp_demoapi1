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
    public class UserService : IUserService
    {
        private readonly IUnitWork _unitWork;
        private readonly IDateTimeService _dateTimeService;
        public UserService(IUnitWork unitWork, IDateTimeService dateTimeService)
        {
            _unitWork = unitWork;
            _dateTimeService = dateTimeService;
        }

        public async Task<bool> CreateUserAsync(UserServiceInput input)
        {
            DateTime dateTime = _dateTimeService.Now;
            User user = _unitWork.UserRepository.GetQueryable().Where(x => x.id == input.id).FirstOrDefault();
            if (user == null)
            {
                user = new User();
                user.created_at = dateTime;
            }
            user.updated_at = dateTime;
            user.is_active = true;
            user.email = input.email;
            user.password = input.password;
            user.firstname = input.firstname;
            user.lastname = input.lastname;
            user.roles = input.roles;
            user.info = input.info;
            await _unitWork.UserRepository.InsertOrUpdateAsynce(user);
            return true;
        }
    }
}
