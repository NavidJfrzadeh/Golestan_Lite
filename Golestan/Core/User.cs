namespace Golestan.Core
{
    public abstract class User
    {
        protected string password;
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public string UserName { get; set; }
        public RoleEnum Role { get; set; }

        public virtual bool SetPassword(string NewPass, out string message)
        {
            message = string.Empty;

            if (NewPass.Length < 6)
            {
                message = "password is less than 6";
                return false;
            }

            password = NewPass;
            message = "password was set";
            return true;
        }

        public virtual bool CheckPassword(string CurrentPass)
        {
            return CurrentPass == password;
        }

        public virtual bool ChangePassword(string CurrentPass, string NewPass, out string Message)
        {
            if (!CheckPassword(CurrentPass))
            {
                Message = "your password is incorrect";
                return false;
            }

            if (CurrentPass == NewPass)
            {
                Message = "your new password must be Different";
                return false;
            }

            SetPassword(NewPass, out Message);
            return true;
        }

    }
}