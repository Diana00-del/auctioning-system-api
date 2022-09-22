using AuctionAPI.Models;
using AuctionAPI.Utils;

namespace AuctionAPI.WebInterface
{
    public class GetUserResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
    
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public User ToUser()
        {
            return new User
            {
                Email = Email,
                Password = PasswordHasher.HashPassword(Password),
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Address = Address,
                City = City,
                State = State,
                Zip = Zip,
                Country = Country
            };
        }
    }

    public class CreateUserResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }

    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public User ToUser(int id)
        {
            return new User
            {
                Id = id,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Address = Address,
                City = City,
                State = State,
                Zip = Zip,
                Country = Country
            };
        }
    }

    public class UpdateUserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }

    public class DeleteUserResponse
    {
        public bool Success { get; set; }

        public static DeleteUserResponse SuccessResponse()
        {
            return new DeleteUserResponse { Success = true };
        }
    }

    public static class UserWebInterfaceExtensions
    {
        public static GetUserResponse ToGetUserResponse(this User user)
        {
            return new GetUserResponse
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Address = user.Address,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                Country = user.Country
            };
        }
        
        public static CreateUserResponse ToCreateUserResponse(this User request)
        {
            return new CreateUserResponse
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Address = request.Address,
                City = request.City,
                State = request.State,
                Zip = request.Zip,
                Country = request.Country
            };
        }

        public static UpdateUserResponse ToUpdateUserResponse(this User request)
        {
            return new UpdateUserResponse
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Address = request.Address,
                City = request.City,
                State = request.State,
                Zip = request.Zip,
                Country = request.Country
            };
        }
    }
}
