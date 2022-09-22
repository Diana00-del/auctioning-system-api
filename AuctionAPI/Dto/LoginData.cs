namespace AuctionAPI.Dto
{
    public class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginStatus
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string Token { get; private set; }

        private LoginStatus(bool success, string message, string token)
        {
            Success = success;
            Message = message;
            Token = token;
        }

        public static LoginStatus Successful(string token) => new LoginStatus(true, "Login successful", token);
        public static LoginStatus UserNotFound() => new LoginStatus(false, "User not found", null);
        public static LoginStatus NotVerified() => new LoginStatus(false, "User not verified", null);
        public static LoginStatus Inactive() => new LoginStatus(false, "User is inactive", null);
        public static LoginStatus WrongPassword() => new LoginStatus(false, "Wrong password", null);
    }
}
