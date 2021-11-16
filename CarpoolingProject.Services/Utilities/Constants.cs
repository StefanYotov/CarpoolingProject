using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Services.Utilities
{
    public class Constants
    {
        public const string TRAVEL_CREATE_SUCCESS = "Travel created successfully";
        public const string TRAVEL_DELETE_SUCCESS = "Travel deleted successfully";
        public const string TRAVEL_NOT_FOUND = "Travel was not found";
        public const string INVALID_PARAMS = "Invalid input";
        public const string TRAVEL_UNATHORIZED = "Barash deto ne ti e rabota";
        public const string TRAVEL_UPDATED_SUCCESS = "Updated successfully travel: ";
        public const string TRAVEL_UPDATE_ERROR = "Couldn't find travel with ";
        public const string COUNTRY_NULL_ERROR = "Country cannot be null";
        public const string COUNTRY_DELETE_SUCCESSFULL = "Country Successfully deleted";
        public const string ADDRESS_CREATE_SUCCESS = "Address created succesfully";
        public const string ADDRESS_DELETED_SUCCESS = "Address was successfully deleted";
        public const string ADDRESS_NOT_FOUND = "Address could not be found";
        public const string CITY_CREATE_SUCCESS = "City Successfully created";
        public const string CITY_DELETE_SUCCESSFULL = "City Successfully deleted";
        public const string CITY_NULL_ERROR = "City cannot be null";
        public const string CITY_ADDED = "City added to Country";
        public const string CITY_EXISTS = "City already exists";
        public const string USER_WRONG_PARAMETERS = "Wrong Parameters";
        public const string USER_CREATE_SUCCESS = "User created successfully";
        public const string USER_NOT_FOUND = "User was not found";
        public const string USER_DELETED = "User deleted successfully";
        public const string USER_UPDATE_ERROR = "Couldn't find user with ";
        public const string USERNAME_ALREADY_EXIST = "Username is already exist";
        public const string EMAIL_ALREADY_EXIST = "Email is already exist";
    }
}
