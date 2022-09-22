namespace AuctionAPI.Dto
{
    public class ChangePasswordStatus
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        private ChangePasswordStatus(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ChangePasswordStatus Successful() => new ChangePasswordStatus(true, "Password changed successfully");
        public static ChangePasswordStatus UserNotFound() => new ChangePasswordStatus(false, "User not found");
        public static ChangePasswordStatus NotVerified() => new ChangePasswordStatus(false, "User not verified");
        public static ChangePasswordStatus Inactive() => new ChangePasswordStatus(false, "User is inactive");
        public static ChangePasswordStatus InvalidPassword() => new ChangePasswordStatus(false, "Old password is incorrect");
    }

    public class ChangePasswordData
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
