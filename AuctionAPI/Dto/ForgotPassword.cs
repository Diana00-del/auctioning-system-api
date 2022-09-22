namespace AuctionAPI.Dto
{
    public class ForgotPasswordStatus
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        private ForgotPasswordStatus(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ForgotPasswordStatus Successful() => new ForgotPasswordStatus(true, null);
        public static ForgotPasswordStatus UserNotFound() => new ForgotPasswordStatus(false, "User not found");
        public static ForgotPasswordStatus NotVerified() => new ForgotPasswordStatus(false, "User not verified");
        public static ForgotPasswordStatus Inactive() => new ForgotPasswordStatus(false, "User is inactive");
    }

    public class ForgotPasswordData
    {
        public string Email { get; set; }
    }
}
