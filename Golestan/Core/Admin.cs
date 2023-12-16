namespace Golestan.Core
{
    public class Admin : User
    {
        public override bool SetPassword(string NewPass, out string message)
        {
            message = string.Empty;

            password = NewPass;
            message = "password was set";
            return true;
        }

        public override bool ChangePassword(string CurrentPass, string NewPass, out string Message)
        {
            if (!CheckPassword(CurrentPass))
            {
                Message = "your password is incorrect";
                return false;
            }

            SetPassword(NewPass, out Message);
            return true;
        }
    }
}