using CarpoolingProject.Data;
using CarpoolingProject.Models.Dtos;
using CarpoolingProject.Models.EntityModels;
using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Models.ResponseModels;
using CarpoolingProject.Services.Exceptions;
using CarpoolingProject.Services.Interfaces;
using CarpoolingProject.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.ServiceImplementation
{
    public class UserService : IUserService
    {
        private readonly CarpoolingContext context;

        public UserService(CarpoolingContext context)
        {
            this.context = context;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return user ?? throw new EntityNotFoundException();
        }
        public async Task<IEnumerable<UserDto>> GetAllPassengers()
        {
            var passengers = await context.Users.Where(x => x.Roles.Any(x => x.Role.Name == "Passenger")).Select(x => new UserDto(x)).ToListAsync();
            return passengers;
        }

        public async Task<InfoResponseModel> CreateUserAsync(CreateUserRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();

            if (requestModel.UserName == null ||
                requestModel.Password == null ||
                requestModel.FirstName == null ||
                requestModel.LastName == null ||
                requestModel.Email == null ||
                requestModel.PhoneNumber < 1
                )
            {
                responseModel.IsSuccess = false;
                responseModel.Message = Constants.USER_WRONG_PARAMETERS;
                return responseModel;
            }

            var user = new User()
            {
                UserName = requestModel.UserName,
                Password = requestModel.Password,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Email = requestModel.Email,
                PhoneNumber = requestModel.PhoneNumber,
                StarsCount = 0,
                TravelCountAsDriver = 0,
                ReviewCount = 0
            };

            if (await context.Users.AnyAsync(x => x.UserName == requestModel.UserName))
            {
                responseModel.IsSuccess = false;
                responseModel.Message = Constants.USERNAME_ALREADY_EXIST;
                return responseModel;
            }

            if (await context.Users.AnyAsync(e => e.Email == requestModel.Email))
            {
                responseModel.IsSuccess = false;
                responseModel.Message = Constants.EMAIL_ALREADY_EXIST;
                return responseModel;
            }

            context.Users.Add(user);
            await context.SaveChangesAsync();

            responseModel.IsSuccess = true;
            responseModel.Message = Constants.USER_CREATE_SUCCESS;
            return responseModel;
        }

        public async Task<InfoResponseModel> DeleteUserAsync(DeleteUserRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == requestModel.Id);

            if (user == null)
            {
                responseModel.Message = Constants.USER_NOT_FOUND;
                responseModel.IsSuccess = false;
            }

            else
            {
                responseModel.Message = Constants.USER_DELETED;
                responseModel.IsSuccess = true;

                this.context.Users.Remove(user);
                await this.context.SaveChangesAsync();
            }
            return responseModel;
        }

        public async Task<InfoResponseModel> UpdateUserAsync(UpdateUserRequestModel requestModel)
        {
            var responseModel = new InfoResponseModel();

            if (requestModel.UserName == null ||
                requestModel.Password == null ||
                requestModel.FirstName == null ||
                requestModel.LastName == null ||
                requestModel.Email == null ||
                requestModel.PhoneNumber < 1
                )
            {
                responseModel.IsSuccess = false;
                responseModel.Message = Constants.USER_WRONG_PARAMETERS;
                return responseModel;
            }
            var user = await GetUser(requestModel.Id);
            //var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == requestModel.Id);
            if (user != null)
            {
                if (requestModel.UserName != user.UserName)
                {

                    if (await context.Users.AnyAsync(x => x.UserName == requestModel.UserName))
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = Constants.USERNAME_ALREADY_EXIST;
                        return responseModel;
                    }
                    user.UserName = requestModel.UserName;
                }

                else if (requestModel.Password != user.Password)
                {
                    user.Password = requestModel.Password;
                }

                else if (requestModel.FirstName != user.FirstName)
                {
                    user.FirstName = requestModel.FirstName;
                }

                else if (requestModel.LastName != user.LastName)
                {
                    user.LastName = requestModel.LastName;
                }

                else if (requestModel.Email != user.Email)
                {
                    if (await context.Users.AnyAsync(e => e.Email == requestModel.Email))
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = Constants.EMAIL_ALREADY_EXIST;
                        return responseModel;
                    }
                    user.Email = requestModel.Email;
                }

                else if (requestModel.PhoneNumber != user.PhoneNumber)
                {
                    user.PhoneNumber = requestModel.PhoneNumber;
                    responseModel.Message = Constants.USER_WRONG_PARAMETERS;
                    responseModel.IsSuccess = false;
                    return responseModel;
                }

                await context.SaveChangesAsync();
                responseModel.Message = Constants.USER_CREATE_SUCCESS + $"{user.UserId}";
                responseModel.IsSuccess = true;
            }
            else
            {
                responseModel.IsSuccess = false;
                responseModel.Message = Constants.USER_UPDATE_ERROR + $"{user.UserId} id";
            }
            return responseModel;
        }
    }
}

