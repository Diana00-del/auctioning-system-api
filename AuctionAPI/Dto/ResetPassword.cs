namespace AuctionAPI.Dto
{
    public class ResetPasswordStatus
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        private ResetPasswordStatus(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ResetPasswordStatus Successful() => new ResetPasswordStatus(true, "Password reset successful");
        public static ResetPasswordStatus UserNotFound() => new ResetPasswordStatus(false, "User not found");
        public static ResetPasswordStatus NotVerified() => new ResetPasswordStatus(false, "User not verified");
        public static ResetPasswordStatus Inactive() => new ResetPasswordStatus(false, "User is inactive");
        public static ResetPasswordStatus InvalidToken() => new ResetPasswordStatus(false, "Invalid token");
    }

    public class ResetPasswordData
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
