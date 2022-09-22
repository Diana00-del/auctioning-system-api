namespace AuctionAPI.Dto
{
    public class VerifyEmailStatus
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        private VerifyEmailStatus(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static VerifyEmailStatus Successful() => new VerifyEmailStatus(true, "Email verified successfully");
        public static VerifyEmailStatus UserNotFound() => new VerifyEmailStatus(false, "User not found");
        public static VerifyEmailStatus Inactive() => new VerifyEmailStatus(false, "User is not active");
        public static VerifyEmailStatus InvalidToken() => new VerifyEmailStatus(false, "Invalid token");
        
    }

    public class VerifyEmailData
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
