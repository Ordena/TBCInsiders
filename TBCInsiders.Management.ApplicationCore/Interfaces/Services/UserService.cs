using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.Domain.Entities;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.ApplicationCore.ValidationRules.UserValidationRule;
using TBCInsiders.Management.ApplicationCore.Models.Filters;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public async Task AddUserAsync(CreateUserDto request) 
        {

            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(request);

            var user = _mapper.Map<User>(request);

            if (validationResult.Errors.Count > 1)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            _uow.Users.Add(user);
            await _uow.CommitAsync();
        }
     
        public async Task<UserDto> GetUserAsync(int id)
        {
            return _mapper.Map<UserDto>(await _uow.Users.GetAsync(id));
        }
        public async Task<UserDetailsDto> GetUserDetailsAsync(int id)
        {
            return _mapper.Map<UserDetailsDto>(await _uow.Users.GetUserDetails(id));
        }

        public async Task UpdateUserAsync(EditUserDto request)
        {   
            var user = _mapper.Map<User>(request);

            await _uow.Users.UpdateAsync(user,request.Id);
            await _uow.CommitAsync();
        }
        public async Task DeleteAsync(int id)
        {
            _uow.Users.Remove(id);
            await _uow.CommitAsync();
        }

       

        public async Task<List<UserDto>> Filter(string firstName, string lastName, string personalNumber, int? pageIndex, int pageSize)
        {
            var result = await _uow.Users.Filter(firstName, lastName, personalNumber, pageIndex, pageSize);

            return _mapper.Map<List<UserDto>>(result);
        }

        public async Task<IEnumerable<UserConnectionsReportDto>> GetReportAsync(int id)
        {
            var result = await _uow.Users.ConnectionsReport(id);

            return result;
        }

        public async Task<IEnumerable<UserDetailsDto>> AdvancedFilter(UserFilter filter, int? pageIndex, int pageSize)
        {
            var users = await _uow.Users.AdvancedFilter(filter, pageIndex, pageSize);

            return _mapper.Map<IEnumerable<UserDetailsDto>>(users);

        }

    } 
}
