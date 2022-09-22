namespace AuctionAPI.Dto
{
    public class ResendVerificationEmailStatus
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        private ResendVerificationEmailStatus(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ResendVerificationEmailStatus Successful() => new ResendVerificationEmailStatus(true, "Successfully sent verification email.");
        public static ResendVerificationEmailStatus UserNotFound() => new ResendVerificationEmailStatus(false, "User not found.");
        public static ResendVerificationEmailStatus Inactive() => new ResendVerificationEmailStatus(false, "User is not active.");
        public static ResendVerificationEmailStatus AlreadyVerified() => new ResendVerificationEmailStatus(false, "User already verified.");
        
    }

    public class ResendVerificationEmailData
    {
        public string Email { get; set; }
    }
}
