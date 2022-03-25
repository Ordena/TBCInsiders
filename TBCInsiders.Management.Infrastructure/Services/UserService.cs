using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.Domain.Entities;
using TBCInsiders.Management.ApplicationCore.ValidationRules.UserValidationRule;
using TBCInsiders.Management.ApplicationCore.Models.Filters;
using TBCInsiders.Management.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using TBCInsiders.Management.ApplicationCore.Helper;
using TBCInsiders.Management.ApplicationCore.Exceptions;

namespace TBCInsiders.Management.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public UserService(IMapper mapper, IUnitOfWork uow, IImageService imageService)
        {
            _mapper = mapper;
            _uow = uow;
            _imageService = imageService;
        }
        public async Task AddUserAsync(CreateUserDto request) 
        {

            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(request);

            var user = _mapper.Map<User>(request);

            if (validationResult.Errors.Count > 1)
            {
                throw new ApplicationCore.Exceptions.ValidationException(validationResult);
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
            var result = _mapper.Map<UserDetailsDto>(await _uow.Users.GetUserDetails(id));
            if (result == null)
            {
                throw new NotFoundException(nameof(User), id);
            }
            return result;
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
            var result = await _uow.Users.Filter(firstName, lastName, personalNumber, pageIndex, pageSize == 0 ? 2: pageSize);

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

        public async Task AddUserAsync(CreateUserDto request, IFormFile file)
        {
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 1)
            {
                throw new ApplicationCore.Exceptions.ValidationException(validationResult);
            }
            var user = _mapper.Map<User>(request);

            string imagePath = String.Empty;
            if (file != null)
            {
                if (file.Length > 0 && ImageExtensionHelper.IsValidExtension(file.FileName))
                {
                    var imageResult = _imageService.ReadImageAsBytes(file);
                    user.Image = imageResult;
                }

            }

            _uow.Users.Add(user);
            await _uow.CommitAsync();
        }

        
    } 
}
